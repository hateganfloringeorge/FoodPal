using FoodPal.Providers.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace FoodPal.Providers.DataAccess
{
    public class ProvidersContext : DbContext
    {

        public ProvidersContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<CatalogueItem> CatalogueItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.SeedDatabase();
        }


    }
}