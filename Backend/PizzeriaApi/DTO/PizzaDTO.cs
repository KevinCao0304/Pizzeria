using PizzeriaApi.Models;

namespace PizzeriaApi.DTO
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public string PizzaName { get; set; }
        public string Toppings { get; set; }
        public decimal Price { get; set; }
        public IList<PizzaToppingDTO> PizzaToppings { get; set; } = new List<PizzaToppingDTO>();
    }
}
