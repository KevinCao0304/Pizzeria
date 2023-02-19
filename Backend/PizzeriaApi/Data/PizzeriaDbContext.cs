using Microsoft.EntityFrameworkCore;
using PizzeriaApi.Models;

namespace PizzeriaApi.Data
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions options):base(options) { 
        
        }
        public DbSet<Store> Store { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<Pizza> Pizza { get; set; }
        public DbSet<PizzaTopping> PizzaTopping { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
