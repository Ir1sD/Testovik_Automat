using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IOrderWithUserService
    {
        /// <summary>
		/// Возвращает список подробных заказов
		/// </summary>
		/// <returns></returns>
        Task<List<OrderWithUser>> GetListAsync();

        /// <summary>
		/// Возвращает список подробной информации о заказе
		/// </summary>
		/// <param name="orderId">Id заказа</param>
		/// <returns></returns>
        Task<List<OrderWithUser>> GetByIdOrder(long orderId);
    }
}