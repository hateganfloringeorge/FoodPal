namespace FoodPal.Orders.Mock.MessageBroker
{
	public interface IQueueNameProvider
	{
		string GetProviderRequestQueueName(string providerId);

		string GetProviderResponseQueueName(string providerId);
	}
}
