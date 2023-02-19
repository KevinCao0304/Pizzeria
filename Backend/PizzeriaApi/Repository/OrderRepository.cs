using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PizzeriaApi.DTO;
using PizzeriaApi.Models;
using PizzeriaApi.Repository.Interface;
using System.IO;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PizzeriaApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public OrderRepository(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<ToppingDTO>> GetExtraToppingList()
        {
            var query = from t in _repositoryWrapper.Topping.GetBy(x => x.ToppingType == "Extra")
                        select new ToppingDTO
                        {
                            ToppingId = t.Id,
                            ToppingName = t.ToppingName,
                            Qty = 0,
                            Price = t.Price
                        };
            return query.ToList();
        }

        public async Task<OrderDTO> GetOrder(int orderId)
        {
            try
            {
                var query = _repositoryWrapper.OrderDetail.GetBy(x => x.OrderId == orderId);
                var result = (from o in _repositoryWrapper.Order.GetBy(x => x.Id == orderId)
                              join s in _repositoryWrapper.Store.GetAll() on o.StoreId equals s.Id
                              select new OrderDTO
                              {
                                  Id = o.Id,
                                  Adress = o.Adress,
                                  FullName = o.FullName,
                                  StoreName = s.StoreName,
                                  StoreId = o.StoreId,
                                  Total = o.Total,
                                  OrderDetails = query
                                          .Select(x =>
                                          new OrderDetailDTO
                                          {
                                              Id = x.Id,
                                              Pizza = x.Pizza,
                                              Extra = x.Extra,
                                              Price = x.Price
                                          }).ToList()
                              }).FirstOrDefaultAsync();
                return await result;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<List<OrderDTO>> GetOrderList()
        {
            var query = from o in _repositoryWrapper.Order.GetAll()
                        join s in _repositoryWrapper.Store.GetAll() on o.StoreId equals s.Id
                        select new OrderDTO
                        {
                            Id = o.Id,
                            Adress = o.Adress,
                            StoreId = o.StoreId,
                            FullName =o.FullName,
                            StoreName = s.StoreName,
                            Total = o.Total
                        };
            return query.ToList();
        }

        public async Task<ApiResponse> SaveOrder(OrderDTO order)
        {
            ApiResponse saveResponse = new ApiResponse();
            try
            {
                var orderDB = _repositoryWrapper.Order.Add(
                        new Order()
                        {
                            FullName = order.FullName,
                            Adress = order.Adress,
                            Total = order.Total,
                            StoreId= order.StoreId,
                            OrderDetails = order.OrderDetails.Select(x => new OrderDetail
                            {
                                Pizza = x.Pizza,
                                Extra = x.Extra,
                                Price= x.Price,
                            }).ToList()
                        }
                    );
                await _repositoryWrapper.Order.SaveChangesAsync();
                saveResponse.ResponseKey = orderDB.Id;
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
