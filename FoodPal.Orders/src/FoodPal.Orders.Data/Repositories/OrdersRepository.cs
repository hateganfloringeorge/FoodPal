using FoodPal.Orders.Data.Contracts;
using FoodPal.Orders.Enums;
using FoodPal.Orders.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPal.Orders.Data.Repositories
{
	public class OrdersRepository : IOrdersRepository
	{
		private readonly OrdersContext _ordersContext;

		public OrdersRepository(OrdersContext ordersContext)
		{
			_ordersContext = ordersContext;
		}

		public async Task<Order> CreateAsync(Order newOrder)
		{
			if (newOrder is null) throw new ArgumentNullException(nameof(newOrder));

			try
			{
				await _ordersContext.AddAsync(newOrder);
				await _ordersContext.SaveChangesAsync();

				return newOrder;
			}
			catch (Exception ex)
			{
				throw new Exception($"Order could not be saved. Reason:{ex.Message}");
			}
		}

		public async Task<Order> GetByIdAsync(int orderId)
		{
			throw new NotImplementedException();
		}

		public async Task<(IEnumerable<Order> Orders, int AllOrdersCount)> GetByFiltersAsync(string customerId, OrderStatus? status, int page, int pageSize)
		{
			throw new NotImplementedException();
		}

		public async Task<OrderStatus?> GetStatusAsync(int orderId)
		{
			throw new NotImplementedException();
		}

		public async Task UpdateStatusAsync(Order orderEntity, OrderStatus newStatus)
		{
			throw new NotImplementedException();
		}
	}
}