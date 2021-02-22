using System.Collections.Generic;

namespace FoodPal.Orders.Mock.Dtos
{
	public class HttpOrderRequestDto
	{
		public int OrderId { get; set; }
		public List<HttpOrderItemRequestDto> OrderItems { get; set; }
	}
}
