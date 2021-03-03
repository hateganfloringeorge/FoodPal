using FoodPal.Deliveries.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Data.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> findCriteria);

        Task<TEntity> FindByIdAsync(int id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);
    }
}