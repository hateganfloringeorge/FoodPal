using FoodPal.Notifications.Data.Abstractions;
using FoodPal.Notifications.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(NotificationDbContext notificationDbSet)
        {
            this._dbSet = notificationDbSet.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public async Task DeleteAsync(int id)
        {
            this.Delete(await this._dbSet.FirstOrDefaultAsync(x => x.Id == id));
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> findCriteria, List<string> toInclude = null)
        {
            var query = this._dbSet.Where(findCriteria);

            if (toInclude is not null)
            {
                foreach (var include in toInclude)
                {
                    query = query.Include(include);
                }
            }

            return query;
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await this._dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            this._dbSet.Update(entity);
        }
    }
}