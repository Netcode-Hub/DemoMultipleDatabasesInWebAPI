using DemoMultipleDatabasesInWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoMultipleDatabasesInWebAPI.Context
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
