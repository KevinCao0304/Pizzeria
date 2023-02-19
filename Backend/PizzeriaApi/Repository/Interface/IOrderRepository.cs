using PizzeriaApi.DTO;

namespace PizzeriaApi.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetOrderList();
        Task<OrderDTO> GetOrder(int orderId);
        Task<ApiResponse> SaveOrder(OrderDTO order);
        Task<List<ToppingDTO>> GetExtraToppingList();

    }
}
