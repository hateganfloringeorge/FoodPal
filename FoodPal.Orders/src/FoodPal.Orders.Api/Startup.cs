using FoodPal.Orders.Data;
using FoodPal.Orders.MessageBroker.Contracts;
using FoodPal.Orders.MessageBroker.ServiceBus;
using FoodPal.Orders.Services;
using FoodPal.Orders.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodPal.Orders.Api
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			services.Configure<MessageBrokerConnectionSettings>(x => Configuration.Bind("MessageBrokerSettings", x));

			services
				.AddTransient<IMessageBroker, ServiceBusMessageBroker>()
				.AddTransient<IOrdersService, OrdersService>();

			var dbConnectionString = Configuration.GetConnectionString("OrdersConnectionString");

			services
				.AddTransient<IOrdersContextFactory, OrdersContextFactory>()
				.AddTransient<IOrdersUnitOfWork, OrdersUnitOfWork>(sp => new OrdersUnitOfWork(sp.GetService<IOrdersContextFactory>().CreateDbContext(dbConnectionString)));

			services.AddSwaggerGen(x =>
			{
				x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Version = "v1",
					Title = "FoodPal Orders API",
					Description = "FoodPal Orders API"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwagger();

			app.UseSwaggerUI(x =>
			{
				x.SwaggerEndpoint($"/swagger/v1/swagger.json", $"FoodPal Orders API v1");
			});

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}