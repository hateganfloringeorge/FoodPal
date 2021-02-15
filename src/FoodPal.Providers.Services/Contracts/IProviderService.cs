using FoodPal.Providers.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.Services.Contracts
{
    public interface IProviderService
    {
        Task<IEnumerable<ProviderDto>> GetAllAsync(bool includeCatalogueItems);
        Task<ProviderDto> GetByIdAsync(int providerId, bool includeCatalogueItems = false);

        Task<bool> ProvidersExistsAsync(string providerName);

        Task<ProviderDto> CreateAsync(NewProviderDto provider);

        Task UpdateAsync(ProviderDto provider);

        Task DeleteAsync(int providerId);
    }
}