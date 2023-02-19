using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PizzeriaApi.DTO
{
    public class ToppingDTO
    {
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
    }
}
