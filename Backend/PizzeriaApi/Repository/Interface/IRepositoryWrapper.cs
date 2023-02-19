using PizzeriaApi.Data.Interface;
using PizzeriaApi.Models;

namespace PizzeriaApi.Repository.Interface
{
    public interface IRepositoryWrapper
    {
        IRepositoryBase<Store> Store { get; }
        IRepositoryBase<Topping> Topping { get; }
        IRepositoryBase<Pizza> Pizza { get; }
        IRepositoryBase<PizzaTopping> PizzaTopping { get; }
        IRepositoryBase<Order> Order { get; }
        IRepositoryBase<OrderDetail> OrderDetail { get; }
    }
}
