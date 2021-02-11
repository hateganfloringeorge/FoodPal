using FoodPal.Providers.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<IEnumerable<Provider>> GetAllWithCatalogueItemsAsync();

        Task<Provider> GetWithCatalogueItemsByIdAsync(int providerId);
    }
}