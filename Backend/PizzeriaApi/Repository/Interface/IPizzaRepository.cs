using PizzeriaApi.DTO;

namespace PizzeriaApi.Repository.Interface
{
    public interface IPizzaRepository
    {
        Task<List<PizzaDTO>> GetPizzaList(int storeId);
        Task<PizzaDTO> GetPizza(int pizzaId);
        Task<ApiResponse> SavePizza(PizzaDTO pizza);
        Task<ApiResponse> DeletePizza(int pizzaId);
    }
}
