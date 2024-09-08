using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IOrderService
    {
        /// <summary>
		/// Возвращает список заказов
		/// </summary>
		/// <returns></returns>
        Task<List<Order>> GetListAsync();

        /// <summary>
		/// Добаляет новый заказ
		/// </summary>
		/// <param name="sum">Сумма заказа</param>
		/// <returns>Id нового заказа</returns>
        Task Add(int sum, List<Tovar> tovars, int[] counts);

	}
}