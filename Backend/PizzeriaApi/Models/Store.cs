using Microsoft.Extensions.Hosting;

namespace PizzeriaApi.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Location { get; set; }
        public IList<Pizza> Pizzas { get; } = new List<Pizza>();
        public IList<Order> Orders { get; } = new List<Order>();
    }
}
