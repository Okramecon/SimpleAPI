using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimpleAPI.DAL.Entities;

namespace SimpleAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("ConnectionString")
                ?? throw new ArgumentNullException("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }
    }
}