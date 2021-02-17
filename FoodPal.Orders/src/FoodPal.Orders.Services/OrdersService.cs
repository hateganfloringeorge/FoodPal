using FoodPal.Orders.Dtos;
using FoodPal.Orders.MessageBroker.Contracts;
using FoodPal.Orders.Services.Contracts;
using System.Threading.Tasks;

namespace FoodPal.Orders.Services
{
	public class OrdersService : BaseService, IOrdersService
	{
		private readonly IMessageBroker _messageBroker;

		public OrdersService(IMessageBroker messageBroker)
		{
			_messageBroker = messageBroker;
		}

		public async Task<string> CreateAsync(NewOrderDto newOrder)
		{
			ValidateNewOrder(newOrder);

			var payload = new MessageBrokerEnvelope<NewOrderDto>(MessageTypes.NewOrder, newOrder);

			await _messageBroker.SendMessageAsync("new-orders", payload);

			return payload.RequestId;
		}

		private void ValidateNewOrder(NewOrderDto newOrder)
		{
			//todo
		}
	}
}