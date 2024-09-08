using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface ITovarService
    {
        /// <summary>
		/// Возвращает список товаров
		/// </summary>
		/// <returns></returns>
        Task<List<Tovar>> GetListAsync();

        /// <summary>
		/// Возвращает список товаров по id бренда
		/// </summary>
		/// <param name="brendId">Id бренда</param>
		/// <returns></returns>
        Task<List<Tovar>> GetListWithFilterAsync(int brendId);

        /// <summary>
        /// Возращает список товаров по списку id
        /// </summary>
        /// <param name="ids">Список id</param>
        /// <returns></returns>
        Task<List<Tovar>> GetListWithListId(long[] ids);

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