using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IOrderWithUserRepository
	{
        /// <summary>
        /// Возвращает список подробных заказов
        /// </summary>
        /// <returns></returns>
        Task<List<OrderWithUser>> GetListAsync();

        /// <summary>
		/// Добавляет данные о заказе
		/// </summary>
		/// <param name="tovars">Список товаров</param>
		/// <param name="counts">Количества</param>
		/// <param name="idOrder">Id заказа</param>
		/// <returns></returns>
		Task AddRange(List<Tovar> tovars, int[] counts, long idOrder);

        /// <summary>
        /// Возвращает список подробной информации о заказе
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns></returns>
        Task<List<OrderWithUser>> GetByIdOrder(long orderId);

    }
}