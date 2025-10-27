using Microsoft.EntityFrameworkCore;
using OrmAPI.Modelo;

namespace OrmAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Region> Region { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


    }
}
