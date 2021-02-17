using FoodPal.Orders.Dtos;
using FoodPal.Orders.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FoodPal.Orders.Api.Controllers
{
	[ApiController]
	[Route("v1/[controller]")]
	public class OrdersController : ControllerBase
	{
		private readonly IOrdersService _ordersService;

		public OrdersController(IOrdersService ordersService)
		{
			_ordersService = ordersService;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status202Accepted)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesErrorResponseType(typeof(ErrorInfoDto))]
		public async Task<ActionResult<string>> CreateOrder(NewOrderDto newOrder)
		{
			var requestId = await _ordersService.CreateAsync(newOrder);
			return Accepted(requestId);
		}
	}
}