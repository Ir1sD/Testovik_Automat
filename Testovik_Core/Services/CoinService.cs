using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class CoinService : ICoinService
	{
		private readonly ICoinRepository _coinRepository;

		public CoinService(ICoinRepository coinRepository)
		{
			_coinRepository = coinRepository;
		}

		public async Task<List<Coin>> GetListAsync()
		{
			return await _coinRepository.GetListAsync();
		}

		public async Task AddRange(int i1 , int i2 , int i5 , int i10)
		{
			await _coinRepository.AddRange(i1, i2, i5, i10);
		}

		public async Task Update(List<Coin> coins)
		{
			await _coinRepository.Update(coins);
		}
	}
}
