using FoodPal.Providers.Dtos.Mappers;
using FoodPal.Providers.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace FoodPal.Providers.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BaseProfile));
            //services.AddAutoMapper(typeof(ProviderProfile), typeof(CatalogueProfile), typeof(CatalogueItemProfile));

            services.AddTransient<IProviderService, ProviderService>();
            services.AddTransient<ICatalogueItemService, CatalogueItemService>();

            return services;
        }
    }
}