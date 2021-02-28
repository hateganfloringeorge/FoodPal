using FoodPal.Notifications.Data;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FoodPal.Notifications.Processor.ContextFactory
{
    public class NotificationDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
    {
        public NotificationDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile("appsettings.Development.json")
                    .Build();

            var connectionString = configuration.GetSection("ConnectionStrings:DbConnection").Value;

            return new NotificationDbContext(connectionString);
        }
    }
}