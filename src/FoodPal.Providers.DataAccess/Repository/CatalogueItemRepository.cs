using FoodPal.Providers.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public class CatalogueItemRepository : Repository<CatalogueItem>, ICatalogueItemRepository
    {

        public CatalogueItemRepository(ProvidersContext providersContext) : base(providersContext)
        {

        }

        public async Task<IEnumerable<CatalogueItem>> GetAllWithProviderIdAsync(int providerId)
        {
            return await _providersContext.CatalogueItems
                .Include(i => i.Category)
                .Include(i => i.Catalogue)
                .ThenInclude(c => c.Provider)
                .Where(x => x.Id == providerId)
                .ToListAsync();
        }

        public async Task<CatalogueItem> GetWithProviderAndCategoryByIdAsync(int catalogueItemId)
        {
            return await _providersContext.CatalogueItems
               .Include(i => i.Category)
               .Include(i => i.Catalogue)
               .ThenInclude(c => c.Provider)
               .SingleOrDefaultAsync(x => x.Id == catalogueItemId);
        }
    }
}
