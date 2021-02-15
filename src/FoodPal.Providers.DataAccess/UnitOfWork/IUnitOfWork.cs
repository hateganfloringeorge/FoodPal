using FoodPal.Providers.DataAccess.Repository;
using FoodPal.Providers.DomainModels;
using System;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        IProviderRepository ProviderRepository { get; }

        ICatalogueItemsRepository CatalogueItemsRepository { get; }

        IRepository<Catalogue> CatalogueRepository { get; }
    }
}