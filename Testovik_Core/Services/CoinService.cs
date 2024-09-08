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

        /// <summary>
        /// Возвращает список монет
        /// </summary>
        /// <returns></returns>
        public async Task<List<Coin>> GetListAsync()
		{
			return await _coinRepository.GetListAsync();
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
			await _coinRepository.AddRange(i1, i2, i5, i10);
		}

        /// <summary>
        /// Обновляет информацию о монетах
        /// </summary>
        /// <param name="coins">Список понет для обновления</param>
        /// <returns></returns>
        public async Task Update(List<Coin> coins)
		{
			await _coinRepository.Update(coins);
		}
	}
}
