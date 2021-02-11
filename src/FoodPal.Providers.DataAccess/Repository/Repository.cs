using FoodPal.Providers.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FoodPal.Providers.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ProvidersContext _providersContext;
        private readonly DbSet<T> _entities;

        public Repository(ProvidersContext providersContext)
        {
            _providersContext = providersContext ?? throw new ArgumentNullException(nameof(providersContext));
            _entities = providersContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            // await _providersContext.Set<T>().AddAsync(entity);
            await _entities.AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _providersContext.Set<T>().ToListAsync();
        }

        public void Remove(T entity)
        {
            _providersContext.Set<T>().Remove(entity);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression)
        {
            return await _providersContext.Set<T>().SingleOrDefaultAsync(expression);
        }
    }
}