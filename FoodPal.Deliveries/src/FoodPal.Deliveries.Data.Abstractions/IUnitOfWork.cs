using FoodPal.Deliveries.Domain;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;

        Task<bool> SaveChangesAsync();
    }
}
