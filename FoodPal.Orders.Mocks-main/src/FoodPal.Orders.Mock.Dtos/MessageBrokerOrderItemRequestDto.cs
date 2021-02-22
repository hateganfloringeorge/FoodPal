namespace FoodPal.Orders.Mock.Dtos
{
	public class MessageBrokerOrderItemRequestDto
	{
		public int OrderItemId { get; set; }
		public string Name { get; set; }
		public short Quantity { get; set; }
	}
}
