using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace PizzeriaApi.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string Adress { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Total { get; set; }

        [Required]
        public int StoreId { get; set; }
        public Store Store { get; set; }
        public IList<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
