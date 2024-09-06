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
	}
}
