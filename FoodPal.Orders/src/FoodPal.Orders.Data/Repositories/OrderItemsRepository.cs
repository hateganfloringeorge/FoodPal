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
    public class OrderItemsRepository : IOrderItemsRepository
	{
		private readonly OrdersContext _ordersContext;

		public OrderItemsRepository(OrdersContext ordersContext)
		{
			_ordersContext = ordersContext;
		}

		public async Task<OrderItem> GetOrderItemAsync(int orderId, int orderItemId)
		{
			try
			{
				return await _ordersContext.OrderItems
					.Where(x => x.OrderId == orderId)
					.Where(x => x.Id == orderItemId)
					.SingleOrDefaultAsync();
			}
			catch (Exception ex)
			{
				throw new Exception($"Order item could not be retrieved. Reason:{ex.Message}");
			}
		}

		public async Task<List<OrderItem>> GetItemsAsync(int orderId)
		{
			try
			{
				return await _ordersContext.OrderItems
					.Where(x => x.OrderId == orderId)
					.ToListAsync();
			}
			catch (Exception ex)
			{
				throw new Exception($"Order items could not be retrieved. Reason:{ex.Message}");
			}
		}

		public async Task UpdateStatusAsync(OrderItem orderItemEntity, OrderItemStatus newStatus)
		{
			if (orderItemEntity is null) throw new ArgumentNullException(nameof(orderItemEntity));

			try
            {
				var orderItem = await _ordersContext.OrderItems
					.SingleOrDefaultAsync(x => x.Id == orderItemEntity.Id);

				if (orderItem == null) throw new Exception("Order item could not be found!");

				orderItem.Status = newStatus;
				_ordersContext.OrderItems.Update(orderItem);
				await _ordersContext.SaveChangesAsync();
            }
			catch (Exception ex)
			{
				throw new Exception($"Order item status could not be updated. Reason:{ex.Message}");
			}

		}
	}
}