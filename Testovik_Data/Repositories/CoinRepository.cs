using Microsoft.EntityFrameworkCore;
using Testovik_Core.Models;
using Testovik_Data.Context;
using Testovik_Core.Abstractions;

namespace Testovik_Data.Repositories
{

	public class CoinRepository : ICoinRepository
	{
		private readonly TestovikContext _context;

		public CoinRepository(TestovikContext context)
		{
			_context = context;
		}

		/// <summary>
		/// Возвращает список монет
		/// </summary>
		/// <returns></returns>
		public async Task<List<Coin>> GetListAsync()
		{
			return await _context.Coins
				.AsNoTracking()
				.Select(c => Coin.New(c.Id, c.Num, c.Count))
				.ToListAsync();
		}
	}
}
