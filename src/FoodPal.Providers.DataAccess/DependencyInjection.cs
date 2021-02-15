using FoodPal.Providers.DataAccess.UnitOfWork;
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

            services.AddTransient<IUnitOfWork, FoodPal.Providers.DataAccess.UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}