using Microsoft.EntityFrameworkCore;
using PizzeriaApi.DTO;
using PizzeriaApi.Models;
using PizzeriaApi.Repository.Interface;
using System.IO;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PizzeriaApi.Repository
{
    public class PizzaRepository : IPizzaRepository
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public PizzaRepository(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<ApiResponse> DeletePizza(int pizzaId)
        {
            ApiResponse deleteResponse = new ApiResponse();
            try
            {
                var pizzaDB = _repositoryWrapper.Pizza.GetBy(x => x.Id == pizzaId).FirstOrDefault();
                if (pizzaDB != null)
                {
                    _repositoryWrapper.Pizza.Delete(pizzaDB);
                }
                await _repositoryWrapper.Pizza.SaveChangesAsync();

                return deleteResponse;
            }
            catch (Exception ex)
            {
                deleteResponse.ResponseMessage = ex.Message;
                return deleteResponse;
            }
        }

        public async Task<PizzaDTO> GetPizza(int pizzaId)
        {
            if (pizzaId == 0)
            {
                return new PizzaDTO
                {
                    Id = 0,
                    PizzaName = "",
                    StoreId = 0,
                    Price = 0,
                    Toppings = "",
                    PizzaToppings = _repositoryWrapper.Topping.GetAll().Select(x => new PizzaToppingDTO
                    {
                        Id = 0,
                        PizzaId = pizzaId,
                        ToppingId = x.Id,
                        ToppingName = x.ToppingName,
                        Qty = 0
                    }).ToList()
                };
            }
            else
            {
                var query = from t in _repositoryWrapper.Topping.GetAll()
                            join p in _repositoryWrapper.PizzaTopping.GetBy(x=>x.PizzaId==pizzaId) on t.Id equals p.ToppingId
                            into d
                            from p in d.DefaultIfEmpty()
                            select new PizzaToppingDTO
                            {
                                Id = p.Id == null ? 0 : p.Id,
                                PizzaId = pizzaId,
                                ToppingId = t.Id,
                                ToppingName = t.ToppingName,
                                Qty = p.Qty == null ? 0 : p.Qty
                            };

                var result = _repositoryWrapper.Pizza.GetBy(x => x.Id == pizzaId)
                    .Select(x => new PizzaDTO
                    {
                        Id = x.Id,
                        PizzaName = x.PizzaName,
                        StoreId = x.StoreId,
                        Price = x.Price,
                        Toppings = "",
                        PizzaToppings = query.Where(y => y.PizzaId == x.Id).ToList()
                    }).FirstOrDefaultAsync();
                return await result;
            }

        }

        public async Task<List<PizzaDTO>> GetPizzaList(int storeId)
        {

            var query = (from p in _repositoryWrapper.Pizza.GetAll()
                         join pt in _repositoryWrapper.PizzaTopping.GetAll() on p.Id equals pt.PizzaId
                         into d
                         from pt in d.DefaultIfEmpty()
                         join t in _repositoryWrapper.Topping.GetAll() on pt.ToppingId equals t.Id
                         into d1
                         from t in d1.DefaultIfEmpty()
                         where p.StoreId == storeId
                         select new
                         {
                             Id = p.Id,
                             PizzaName = p.PizzaName,
                             Toppings = t.ToppingName == null ? "" : t.ToppingName,
                             Qty = pt.Qty == null ? 0 : pt.Qty,
                             Price = p.Price
                         });
            
            var result = query.ToList().GroupBy(t => new { t.Id, t.PizzaName, t.Price }).Select(t => new PizzaDTO
            {
                Id = t.Key.Id,
                PizzaName = t.Key.PizzaName,
                Toppings = t == null ? "" : string.Join(" | ", t.Select(x => x.Toppings + (x.Qty == 0 ? "" : " (" + x.Qty + ")"))),
                Price = t.Key.Price
            }).ToList();

            return result;
        }

        public async Task<ApiResponse> SavePizza(PizzaDTO pizza)
        {
            ApiResponse saveResponse = new ApiResponse();
            try
            {
                var pizzaDB = _repositoryWrapper.Pizza.GetBy(x => x.Id == pizza.Id).FirstOrDefault();
                if (pizzaDB != null)
                {
                    var pizzaToppingDB = _repositoryWrapper.PizzaTopping.GetBy(x => x.PizzaId == pizza.Id).ToList();
                    pizzaDB.PizzaName = pizza.PizzaName;
                    pizzaDB.Price = pizza.Price;
                    _repositoryWrapper.Pizza.Edit(pizzaDB);
                    _repositoryWrapper.PizzaTopping.DeleteRange(pizzaToppingDB);
                    _repositoryWrapper.PizzaTopping.AddRange(pizza.PizzaToppings.Where(x => x.Qty != 0).Select(x => new PizzaTopping
                    {
                        PizzaId = x.PizzaId,
                        ToppingId = x.ToppingId,
                        Qty = x.Qty
                    }).ToList());
                }
                else
                {
                    pizzaDB = _repositoryWrapper.Pizza.Add(
                        new Pizza()
                        {
                            PizzaName = pizza.PizzaName,
                            StoreId = pizza.StoreId,
                            Price= pizza.Price,
                            PizzaToppings= pizza.PizzaToppings.Where(x => x.Qty != 0).Select(x => new PizzaTopping
                            {
                                ToppingId = x.ToppingId,
                                Qty = x.Qty
                            }).ToList()
                        }
                    );
                }
                await _repositoryWrapper.Store.SaveChangesAsync();
                saveResponse.ResponseKey = pizzaDB.Id;
                return saveResponse;
            }
            catch (Exception ex)
            {
                saveResponse.ResponseMessage = ex.Message;
                return saveResponse;
            }
        }
    }
}
