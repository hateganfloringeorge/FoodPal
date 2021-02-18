using FoodPal.Orders.Data.Contracts;
using FoodPal.Orders.Enums;
using FoodPal.Orders.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
			try
            {
				return await _ordersContext.Orders
					.Where(x => x.Id == orderId)
					.SingleOrDefaultAsync();
            }
			catch (Exception ex)
			{
				throw new Exception($"Order could not be retrieved. Reason:{ex.Message}");
			}
		}

		public async Task<(IEnumerable<Order> Orders, int AllOrdersCount)> GetByFiltersAsync(string customerId, OrderStatus? status, int page, int pageSize)
		{
			if (customerId == null) throw new ArgumentNullException(nameof(customerId));

			try
            {
				// considered page indexing starting from 1
				var orderList = await _ordersContext.Orders
					.Where(x => x.CustomerId == customerId)
					.Where(x => status == null || x.Status == status)
					.Skip((page - 1) * pageSize)
					.Take(pageSize)
					.ToListAsync();

				return (orderList, orderList.Count);
			}
			catch (Exception ex)
			{
				throw new Exception($"Orders could not be retrieved. Reason:{ex.Message}");
			}
		}

		public async Task<OrderStatus?> GetStatusAsync(int orderId)
		{
			try
            {
				var order = await _ordersContext.Orders
					.Where(x => x.Id == orderId)
					.SingleOrDefaultAsync();

				if (order == null) return null;

				return order.Status;
            }
			catch (Exception ex)
			{
				throw new Exception($"Order status could not be retrieved. Reason:{ex.Message}");
			}
		}

		public async Task UpdateStatusAsync(Order orderEntity, OrderStatus newStatus)
		{
			if (orderEntity == null) throw new ArgumentNullException(nameof(orderEntity));

			try
            {
				var order = await _ordersContext.Orders
					.SingleOrDefaultAsync(x => x.Id == orderEntity.Id);

				if (order == null) throw new Exception("Order could not be found!");

				order.Status = newStatus;
				_ordersContext.Orders.Update(order);
				await _ordersContext.SaveChangesAsync();
			}
			catch (Exception ex)
			{
				throw new Exception($"Order status could not be updated. Reason:{ex.Message}");
			}
		}
	}
}