using FoodPal.Deliveries.Messages;
using FoodPal.Notifications.Processor;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Processor
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices(ConfigureServices)
                .ConfigureAppConfiguration(ConfigureAppConfiguration)
                .RunConsoleAsync();
        }

        private static void ConfigureServices(HostBuilderContext hostBuilder, IServiceCollection services)
        {
            services.AddHostedService<MassTransitConsoleHostedService>();

            services.AddScoped<NewUserAddedConsumer>();
            services.AddScoped<UserUpdatedConsumer>();

            services.AddMassTransit(configuration =>
            {
                configuration.UsingAzureServiceBus((context, config) =>
                {
                    config.Host("");

                    config.ReceiveEndpoint("deliveries-users-queue", e =>
                    {
                        e.Consumer(() => context.GetService<NewUserAddedConsumer>());
                        e.Consumer(() => context.GetService<UserUpdatedConsumer>());
                    });
                });
            });
        }

        private static void ConfigureAppConfiguration(HostBuilderContext arg1, IConfigurationBuilder arg2)
        {
            throw new NotImplementedException();
        }
    }
}
