using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaApi.Models
{
    public class PizzaTopping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [Required]
        public int ToppingId { get; set; }
        public Topping Topping { get; set; }
        [Required]
        public int Qty { get; set; }
    }
}
