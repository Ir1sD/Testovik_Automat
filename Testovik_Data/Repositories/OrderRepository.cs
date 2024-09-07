using Microsoft.EntityFrameworkCore;
using Testovik_Core.Models;
using Testovik_Data.Context;
using Testovik_Core.Abstractions;
using Testovik_Data.Entities;

namespace Testovik_Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly TestovikContext _context;

		public OrderRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список заказов
		/// </summary>
		/// <returns></returns>
		public async Task<List<Order>> GetListAsync()
		{
			return await _context.Orders
				.AsNoTracking()
				.Select(c => Order.New(c.Id, c.DateCreate, c.Sum))
				.ToListAsync();
		}

		/// <summary>
		/// Добаляет новый заказ
		/// </summary>
		/// <param name="sum">Сумма заказа</param>
		/// <returns>Id нового заказа</returns>
		public async Task<long> Add(int sum)
		{
			var item = new OrderEntity()
			{
				DateCreate = DateTime.Now,
				Sum = sum
			};

			await _context.Orders.AddAsync(item);
			await _context.SaveChangesAsync();

			return _context.Orders.OrderByDescending(o => o.Id).First().Id;
		}
	}
}
