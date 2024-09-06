using Testovik_Core.Models;
using Testovik_Core.Abstractions;
using Testovik_Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Testovik_Data.Repositories
{
	public class OrderWithUserRepository : IOrderWithUserRepository
	{
		private readonly TestovikContext _context;

		public OrderWithUserRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список подробных заказов
		/// </summary>
		/// <returns></returns>
		public async Task<List<OrderWithUser>> GetListAsync()
		{
			return await _context.OrdersWithUsers
				.AsNoTracking()
				.Select(c => OrderWithUser.New(c.Id, c.IdOrder, c.IdTovar, c.NameTovar, c.Count))
				.ToListAsync();
		}
	}
}
