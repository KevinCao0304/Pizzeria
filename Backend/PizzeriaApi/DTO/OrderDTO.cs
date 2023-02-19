using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzeriaApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public decimal Total { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public IList<OrderDetailDTO> OrderDetails { get; set; } = new List<OrderDetailDTO>();
    }
}
