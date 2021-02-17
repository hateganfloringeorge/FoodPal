using FoodPal.Orders.Data.Contracts;
using FoodPal.Orders.Enums;
using FoodPal.Orders.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Orders.Data.Repositories
{
	public class OrderItemsRepository : IOrderItemsRepository
	{
		private readonly OrdersContext _ordersContext;

		public OrderItemsRepository(OrdersContext ordersContext)
		{
			_ordersContext = ordersContext;
		}

		public async Task<OrderItem> GetOrderItemAsync(int orderId, int orderItemId)
		{
			throw new NotImplementedException();
		}

		public async Task<List<OrderItem>> GetItemsAsync(int orderId)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateStatusAsync(OrderItem orderItemEntity, OrderItemStatus newStatus)
		{
			throw new NotImplementedException();
		}
	}
}