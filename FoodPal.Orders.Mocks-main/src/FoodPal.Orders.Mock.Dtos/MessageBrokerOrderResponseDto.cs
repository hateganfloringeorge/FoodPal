using System.Collections.Generic;

namespace FoodPal.Orders.Mock.Dtos
{
	public class MessageBrokerOrderResponseDto
	{
		public int OrderId { get; set; }
		public List<int> OrderItemIds { get; set; }
	}
}
