using FoodPal.Providers.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.Services.Contracts
{
    public interface ICatalogueItemService
    {
        Task<IEnumerable<CatalogueItemDto>> GetCatalogueItemsForProviderAsync(int providerId);

        Task<CatalogueItemDto> GetCatalogueItemByIdAsync(int catalogueItemId);

        Task<bool> CatalogueItemExistsAsync(string catalogueItemName, int providerId);

        Task<int> CreateAsync(NewCatalogueItemDto catalogueItem);

        Task UpdateAsync(CatalogueItemDto catalogueItem);

        Task DeleteAsync(int catalogueItemId);
    }
}