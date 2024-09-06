using Microsoft.EntityFrameworkCore;
using Testovik_Core.Abstractions;
using Testovik_Core.Models;
using Testovik_Data.Context;

namespace Testovik_Data.Repositories
{
	public class TovarRepository : ITovarRepository
	{
		private readonly TestovikContext _context;

		public TovarRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список товаров
		/// </summary>
		/// <returns></returns>
		public async Task<List<Tovar>> GetListAsync()
		{
			return await _context.Tovars
				.AsNoTracking()
				.Select(c => Tovar.New(c.Id, c.Name, c.IdBrend, c.LogoPath, c.Price))
				.ToListAsync();
		}
	}
}
