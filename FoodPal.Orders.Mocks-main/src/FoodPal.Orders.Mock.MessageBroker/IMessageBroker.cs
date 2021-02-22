using System.Threading.Tasks;

namespace FoodPal.Orders.Mock.MessageBroker
{
	public delegate Task MessageReceivedEventHandler(string queueMessage);

	public interface IMessageBroker
	{
		Task SendMessageAsync<TMessage>(string queueName, TMessage messageEnvelope);

		void RegisterMessageReceiver(string queueName, MessageReceivedEventHandler messageHandler);

		Task StartListenerAsync();

		Task StopListenerAsync();
	}
}
