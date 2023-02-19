using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace PizzeriaApi.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Pizza { get; set; }
        [StringLength(500)]
        public string Extra { get; set; }
        [Required]
        [Column(TypeName = "decimal(7, 2)")]
        public decimal Price { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
