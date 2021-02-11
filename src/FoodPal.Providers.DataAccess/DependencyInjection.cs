using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodPal.Providers.DataAccess
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProvidersContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}