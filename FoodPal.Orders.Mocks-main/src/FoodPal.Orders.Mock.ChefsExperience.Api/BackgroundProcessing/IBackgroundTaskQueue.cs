using System;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Orders.Mock.ChefsExperience.Api.BackgroundProcessing
{
	public interface IBackgroundTaskQueue
	{
		void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

		Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
	}
}
