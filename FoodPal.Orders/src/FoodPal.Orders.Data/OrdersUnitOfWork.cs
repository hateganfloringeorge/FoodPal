using FoodPal.Orders.Data.Contracts;
using FoodPal.Orders.Data.Repositories;
using System;

namespace FoodPal.Orders.Data
{
	public class OrdersUnitOfWork : IOrdersUnitOfWork
	{
		private readonly Lazy<IOrdersRepository> _ordersRepository;
		private readonly Lazy<IOrderItemsRepository> _orderItemsRepository;

		public OrdersUnitOfWork(OrdersContext dbContext)
		{
			_ordersRepository = new Lazy<IOrdersRepository>(new OrdersRepository(dbContext));
			_orderItemsRepository = new Lazy<IOrderItemsRepository>(new OrderItemsRepository(dbContext));
		}

		public IOrdersRepository OrdersRepository => _ordersRepository.Value;

		public IOrderItemsRepository OrderItemsRepository => _orderItemsRepository.Value;
	}
}