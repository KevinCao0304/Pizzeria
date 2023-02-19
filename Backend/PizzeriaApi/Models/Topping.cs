using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaApi.Models
{
    public class Topping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string ToppingName { get; set; }
        [Required]
        [StringLength(10)]
        public string ToppingType { get; set; }
        [Required]
        [Column(TypeName = "decimal(3, 2)")]
        public decimal Price { get; set; }
        public IList<PizzaTopping> PizzaToppings { get; } = new List<PizzaTopping>();
    }
}
