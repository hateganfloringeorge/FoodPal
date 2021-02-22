using FoodPal.Orders.Mock.Dtos;
using FoodPal.Orders.Mock.MessageBroker;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPal.Orders.Mock.BackgroundServices.Workers
{
	public abstract class BaseWorker
	{
		protected readonly IMessageBroker MessageBroker;
		protected readonly IQueueNameProvider QueueNameProvider;

		public BaseWorker(IMessageBroker messageBroker, IQueueNameProvider queueNameProvider)
		{
			MessageBroker = messageBroker;
			QueueNameProvider = queueNameProvider;
		}

		protected async Task ProcessMessageAsync(string messageEnvelopeAsString, string providerName, int secondsRequiredForProcessing)
		{
			try
			{
				var payload = JsonConvert.DeserializeObject<MessageEnvelope<MessageBrokerOrderRequestDto>>(messageEnvelopeAsString);

				await Task.Delay(TimeSpan.FromSeconds(secondsRequiredForProcessing));
				await MessageBroker.SendMessageAsync(QueueNameProvider.GetProviderResponseQueueName(providerName),
					new MessageEnvelope<MessageBrokerOrderResponseDto>("order-completed", new MessageBrokerOrderResponseDto
					{
						OrderId = payload.Data.OrderId,
						OrderItemIds = payload.Data.OrderItems.Select(x => x.OrderItemId).ToList()
					}));
			}
			catch (Exception ex)
			{
				throw new Exception("Message processing failed.", ex);
			}
		}
	}
}
