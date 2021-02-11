using FoodPal.Providers.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public interface ICatalogueItemRepository : IRepository<CatalogueItem>
    {
        Task<IEnumerable<CatalogueItem>> GetAllWithProviderIdAsync(int providerId);

        Task<CatalogueItem> GetWithProviderAndCategoryByIdAsync(int catalogueItemId);
    }
}
