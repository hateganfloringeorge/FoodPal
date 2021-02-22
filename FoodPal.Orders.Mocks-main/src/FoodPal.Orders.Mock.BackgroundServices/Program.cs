using FoodPal.Orders.Mock.BackgroundServices.Workers;
using FoodPal.Orders.Mock.MessageBroker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodPal.Orders.Mock.BackgroundServices
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureServices((hostContext, services) =>
				{
					var messageBrokerEndpointKfc = hostContext.Configuration["MessageBrokerEndpoint"];

					services.AddTransient<IMessageBroker>(sp =>
					{
						return new ServiceBusMessageBroker(messageBrokerEndpointKfc);
					});

					services.AddSingleton<IQueueNameProvider, QueueNameProvider>(sp =>
					{
						return new QueueNameProvider("brotaru");
					});

					services.AddHostedService<KfcWorker>();
					services.AddHostedService<XyzWorker>();
				});
	}
}
