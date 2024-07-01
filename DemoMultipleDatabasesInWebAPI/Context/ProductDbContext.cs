using DemoMultipleDatabasesInWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMultipleDatabasesInWebAPI.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
