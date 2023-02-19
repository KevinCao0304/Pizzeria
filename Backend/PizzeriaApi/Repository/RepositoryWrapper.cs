using PizzeriaApi.Data;
using PizzeriaApi.Data.Interface;
using PizzeriaApi.Models;
using PizzeriaApi.Repository.Interface;

namespace PizzeriaApi.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private readonly PizzeriaDbContext _dbContext;
        private IRepositoryBase<Store> _store;
        private IRepositoryBase<Topping> _topping;
        private IRepositoryBase<Pizza> _pizza;
        private IRepositoryBase<PizzaTopping> _pizzaTopping;
        private IRepositoryBase<Order> _order;
        private IRepositoryBase<OrderDetail> _orderDetail;
        public RepositoryWrapper(PizzeriaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IRepositoryBase<Store> Store
        {
            get { return _store ?? (_store = new RepositoryBase<Store>(_dbContext)); }
        }
        public IRepositoryBase<Topping> Topping
        {
            get { return _topping ?? (_topping = new RepositoryBase<Topping>(_dbContext)); }
        }
        public IRepositoryBase<Order> Order
        {
            get { return _order ?? (_order = new RepositoryBase<Order>(_dbContext)); }
        }
        public IRepositoryBase<OrderDetail> OrderDetail
        {
            get { return _orderDetail ?? (_orderDetail = new RepositoryBase<OrderDetail>(_dbContext)); }
        }
        public IRepositoryBase<Pizza> Pizza
        {
            get { return _pizza ?? (_pizza = new RepositoryBase<Pizza>(_dbContext)); }
        }
        public IRepositoryBase<PizzaTopping> PizzaTopping
        {
            get { return _pizzaTopping ?? (_pizzaTopping = new RepositoryBase<PizzaTopping>(_dbContext)); }
        }
    }
}
