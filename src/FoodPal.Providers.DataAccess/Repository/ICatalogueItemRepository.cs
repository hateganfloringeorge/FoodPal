using FoodPal.Providers.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public interface ICatalogueItemsRepository : IRepository<CatalogueItem>
    {
        Task<IEnumerable<CatalogueItem>> GetAllWithProviderAsync(int providerId);
        Task<CatalogueItem> GetWithProviderByIdAsync(int catalogueItemId);
    }
}