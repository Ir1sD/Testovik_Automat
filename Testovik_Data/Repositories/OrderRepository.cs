using Microsoft.EntityFrameworkCore;
using Testovik_Core.Models;
using Testovik_Data.Context;
using Testovik_Core.Abstractions;

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
	}
}
