using System.Collections.Generic;

namespace FoodPal.Orders.Mock.Dtos
{
	public class MessageBrokerOrderRequestDto
	{
		public int OrderId { get; set; }
		public List<MessageBrokerOrderItemRequestDto> OrderItems { get; set; }
	}
}
