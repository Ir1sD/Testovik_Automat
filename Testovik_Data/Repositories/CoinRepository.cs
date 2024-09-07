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

		/// <summary>
		/// Добавляет количества монет
		/// </summary>
		/// <param name="i1">1 рубль</param>
		/// <param name="i2">2 рубля</param>
		/// <param name="i5">5 рублей</param>
		/// <param name="i10">10 рублей</param>
		/// <returns></returns>
		public async Task AddRange(int i1 , int i2 , int i5 , int i10)
		{
			var coin = await _context.Coins.FirstOrDefaultAsync(c => c.Num == 1);
			coin.Count += i1;
			_context.Coins.Update(coin);

			coin = await _context.Coins.FirstOrDefaultAsync(c => c.Num == 2);
			coin.Count += i2;
			_context.Coins.Update(coin);

			coin = await _context.Coins.FirstOrDefaultAsync(c => c.Num == 5);
			coin.Count += i5;
			_context.Coins.Update(coin);

			coin = await _context.Coins.FirstOrDefaultAsync(c => c.Num == 10);
			coin.Count += i10;
			_context.Coins.Update(coin);

			await _context.SaveChangesAsync();
		}
	}
}
