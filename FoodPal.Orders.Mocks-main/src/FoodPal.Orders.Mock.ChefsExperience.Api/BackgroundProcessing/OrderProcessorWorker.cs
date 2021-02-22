using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Orders.Mock.ChefsExperience.Api.BackgroundProcessing
{
	public class OrderProcessorWorker : BackgroundService
	{
		private readonly ILogger<OrderProcessorWorker> _logger;
		private readonly IBackgroundTaskQueue _taskQueue;

		public OrderProcessorWorker(ILogger<OrderProcessorWorker> logger, IBackgroundTaskQueue taskQueue)
		{
			_logger = logger;
			_taskQueue = taskQueue;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			_logger.LogInformation($"{this.GetType().Name} is running.");
			await BackgroundProcessing(stoppingToken);
		}

		private async Task BackgroundProcessing(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				var workItem = await _taskQueue.DequeueAsync(stoppingToken);

				if (workItem is null) continue;
				
				try
				{
					await workItem(stoppingToken);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, $"Error occurred executing {nameof(workItem)}.");
				}
			}
		}
	}
}
