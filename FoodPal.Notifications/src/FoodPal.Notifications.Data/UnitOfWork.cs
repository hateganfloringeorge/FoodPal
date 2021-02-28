using FoodPal.Notifications.Data.Abstractions;
using FoodPal.Notifications.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NotificationDbContext _notificationDbContext;

        public UnitOfWork(NotificationDbContext notificationDbContext)
        {
            this._notificationDbContext = notificationDbContext;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
        {
            return new Repository<TEntity>(this._notificationDbContext);
        }

        public async Task<bool> SaveChangesAsnyc() => await this._notificationDbContext.SaveChangesAsync() > 0;
    }
}