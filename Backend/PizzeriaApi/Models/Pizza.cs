using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace PizzeriaApi.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PizzaName { get; set; }
        [Required]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public IList<PizzaTopping> PizzaToppings { get; set; } = new List<PizzaTopping>();
    }
}
