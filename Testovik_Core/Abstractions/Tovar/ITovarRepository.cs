using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface ITovarRepository
	{
        /// <summary>
        /// Возвращает список товаров
        /// </summary>
        /// <returns></returns>
        Task<List<Tovar>> GetListAsync();

        /// <summary>
		/// Обновляет информацию о товаре
		/// </summary>
		/// <param name="tovar">Объект товара</param>
		/// <returns></returns>
		Task Update(Tovar tovar);

        /// <summary>
		/// Добавляет товар
		/// </summary>
		/// <param name="tovar">Обхект товара</param>
		/// <returns></returns>
        Task Add(Tovar tovar);

    }
}