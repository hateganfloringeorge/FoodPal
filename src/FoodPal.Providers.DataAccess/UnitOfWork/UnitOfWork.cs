using FoodPal.Providers.DataAccess.Repository;
using FoodPal.Providers.DomainModels;
using System;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProvidersContext _providersContext;
        private ProviderRepository _providerRepo;
        private CatalogueItemsRepository _catalogueItemsRepo;
        private Repository<Catalogue> _catalogueRepo;

        public UnitOfWork(ProvidersContext providersContext)
        {
            _providersContext = providersContext ?? throw new ArgumentNullException(nameof(providersContext));
        }

        public IProviderRepository ProviderRepository =>
            _providerRepo ??= new ProviderRepository(_providersContext);

        public ICatalogueItemsRepository CatalogueItemsRepository =>
                _catalogueItemsRepo ??= new CatalogueItemsRepository(_providersContext);

        public IRepository<Catalogue> CatalogueRepository =>
            _catalogueRepo ??= new Repository<Catalogue>(_providersContext);

        public async Task<int> CommitAsync()
        {
            return await _providersContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _providersContext.Dispose();
        }
    }
}