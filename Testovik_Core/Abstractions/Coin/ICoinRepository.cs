using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface ICoinRepository
	{
        /// <summary>
        /// Возвращает список монет
        /// </summary>
        /// <returns></returns>
        Task<List<Coin>> GetListAsync();

        /// <summary>
		/// Добавляет количества монет
		/// </summary>
		/// <param name="i1">1 рубль</param>
		/// <param name="i2">2 рубля</param>
		/// <param name="i5">5 рублей</param>
		/// <param name="i10">10 рублей</param>
		/// <returns></returns>
		Task AddRange(int i1, int i2, int i5, int i10);

        /// <summary>
        /// Обновляет информацию о монетах
        /// </summary>
        /// <param name="coins">Список понет для обновления</param>
        /// <returns></returns>
        Task Update(List<Coin> coins);
	}
}