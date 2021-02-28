using FoodPal.Notifications.Common.Settings;
using FoodPal.Notifications.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodPal.Notifications.Data
{
    public class NotificationDbContext : DbContext
    {
        private readonly DbSettings _dbSetting;

        public DbSet<User> Users { get; set; }

        public DbSet<User> Notifications { get; set; }

        public NotificationDbContext(string connectionString)
        {
            this._dbSetting = new DbSettings()
            {
                DbConnection = connectionString
            };
        }

        public NotificationDbContext(IOptions<DbSettings> dbSetting)
        {
            this._dbSetting = dbSetting.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._dbSetting.DbConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.PhoneNo).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Notification>().HasKey(x => x.Id);
            modelBuilder.Entity<Notification>().Property(x => x.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Notification>().Property(x => x.Message).IsRequired();
            modelBuilder.Entity<Notification>().Property(x => x.Type).IsRequired();
            modelBuilder.Entity<Notification>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Notification>().HasOne(x => x.User).WithMany(x => x.Notifications);
        }
    }
}