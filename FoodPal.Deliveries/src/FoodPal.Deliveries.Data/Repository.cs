using FoodPal.Deliveries.Data.Abstractions;
using FoodPal.Deliveries.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Data
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public void Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> findCriteria)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
