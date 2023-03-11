using Microsoft.EntityFrameworkCore;
using SimpleAPI.BLL.Contracts;
using SimpleAPI.BLL.Services;
using SimpleAPI.DAL;
using SimpleAPI.DAL.Contracts;
using SimpleAPI.DAL.Repositories;

namespace SimpleAPI.Api.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public const string DEFAULT_CONNECTION_STRING_NAME = "ConnectionString";
        
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        }
        
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DEFAULT_CONNECTION_STRING_NAME);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public static void RegisterBllServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
