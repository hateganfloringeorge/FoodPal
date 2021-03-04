using FoodPal.Deliveries.Common.Settings;
using FoodPal.Deliveries.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FoodPal.Deliveries.Data
{
    class DeliveryDbContext : DbContext
    {
        private readonly DbSettings _dbSettings;

        public DbSet<User> Users { get; set; }
        public DbSet<User> Deliveries { get; set; }

        protected DeliveryDbContext(string connectionString)
        {
            this._dbSettings = new DbSettings()
            {
                DbConnection = connectionString
            };
        }

        protected DeliveryDbContext(IOptions<DbSettings> dbSettings)
        {
            this._dbSettings = dbSettings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this._dbSettings.DbConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.PhoneNo).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Delivery>().HasKey(x => x.Id);
            modelBuilder.Entity<Delivery>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<Delivery>().Property(x => x.OrderId).IsRequired();
            modelBuilder.Entity<Delivery>().Property(x => x.Status).IsRequired();
            modelBuilder.Entity<Delivery>().Property(x => x.Info).IsRequired();
            modelBuilder.Entity<Delivery>().HasOne(x => x.User).WithMany(x => x.Deliveries);
        }
    }
}
