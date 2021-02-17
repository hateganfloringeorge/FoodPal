using FoodPal.Orders.Dtos;
using System.Threading.Tasks;

namespace FoodPal.Orders.Services.Contracts
{
	public interface IOrdersService
	{
		Task<string> CreateAsync(NewOrderDto newOrder);
	}
}