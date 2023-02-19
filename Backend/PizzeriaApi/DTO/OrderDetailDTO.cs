using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.DTO
{
    public class OrderDetailDTO
    {
        public int Id { get; set; }
        public string Pizza { get; set; }
        public string Extra { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
    }
}
