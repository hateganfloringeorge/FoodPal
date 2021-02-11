using FoodPal.Providers.DomainModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {

        public ProviderRepository(ProvidersContext providersContext) : base(providersContext)
        {

        }

        public async Task<IEnumerable<Provider>> GetAllWithCatalogueItemsAsync()
        {
            return await _providersContext.Providers
                .Include(p => p.Category)
                .Include(p => p.Catalogue)
                .ThenInclude(c => c.Items)
                .ThenInclude(i => i.Category)
                .ToListAsync();

        }

        public async Task<Provider> GetWithCatalogueItemsByIdAsync(int providerId)
        {
            return await _providersContext.Providers
               .Include(p => p.Category)
               .Include(p => p.Catalogue)
               .ThenInclude(c => c.Items)
               .ThenInclude(i => i.Category)
               .SingleOrDefaultAsync(x => x.Id == providerId);
        }
    }
}