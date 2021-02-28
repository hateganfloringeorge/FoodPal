using FoodPal.Notifications.Domain;
using System;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Data.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task<bool> SaveChangesAsnyc();
    }
}