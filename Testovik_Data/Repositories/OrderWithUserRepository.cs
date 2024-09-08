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

		public async Task AddRange(List<Tovar> tovars , int[] counts , long idOrder)
		{
			for(int i = 0; i < tovars.Count; i++)
			{
				var ord = new Entities.OrderWithUserEntity()
				{
					Count = counts[i],
					IdOrder = idOrder,
					IdTovar = tovars[i].Id,
					NameTovar = tovars[i].Name,
				};

				await _context.OrdersWithUsers.AddAsync(ord);
			}

			await _context.SaveChangesAsync();
		}

        public async Task<List<OrderWithUser>> GetByIdOrder(long orderId)
		{
			var list = await _context.OrdersWithUsers
				.AsNoTracking()
				.Where(c => c.IdOrder == orderId)
				.Select(c => OrderWithUser.New(c.Id , c.IdOrder , c.IdTovar , c.NameTovar , c.Count))
				.ToListAsync();

			return list;
		}

    }
}
