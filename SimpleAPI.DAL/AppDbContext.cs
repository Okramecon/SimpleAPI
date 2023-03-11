using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleAPI.DAL.Entities;

namespace SimpleAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}