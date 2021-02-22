using System;

namespace FoodPal.Orders.Mock.MessageBroker
{
	public class QueueNameProvider : IQueueNameProvider
	{
		private readonly string _providerRequestQueueNameTemplate = "provider";

		public QueueNameProvider(string prefix)
		{
			if (!string.IsNullOrEmpty(prefix))
			{
				_providerRequestQueueNameTemplate = $"{prefix}-{_providerRequestQueueNameTemplate}";
			}
		}

		public string GetProviderRequestQueueName(string providerId)
		{
			if (string.IsNullOrEmpty(providerId)) throw new ArgumentException(nameof(providerId));

			return $"{_providerRequestQueueNameTemplate}-{providerId}-request";
		}

		public string GetProviderResponseQueueName(string providerId)
		{
			if (string.IsNullOrEmpty(providerId)) throw new ArgumentException(nameof(providerId));

			return $"{_providerRequestQueueNameTemplate}-{providerId}-response";
		}
	}
}
