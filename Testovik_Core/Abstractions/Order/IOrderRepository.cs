using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IOrderRepository
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
		Task<long> Add(int sum);
	}
}