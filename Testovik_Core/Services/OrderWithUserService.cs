using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class OrderWithUserService : IOrderWithUserService
	{
		private readonly IOrderWithUserRepository orderWithUserRepository;

		public OrderWithUserService(IOrderWithUserRepository orderWithUserRepository)
		{
			this.orderWithUserRepository = orderWithUserRepository;
		}

        /// <summary>
        /// Возвращает список подробных заказов
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrderWithUser>> GetListAsync()
		{
			return await orderWithUserRepository.GetListAsync();
		}

        /// <summary>
        /// Возвращает список подробной информации о заказе
        /// </summary>
        /// <param name="orderId">Id заказа</param>
        /// <returns></returns>
        public async Task<List<OrderWithUser>> GetByIdOrder(long orderId)
		{
			return await orderWithUserRepository.GetByIdOrder(orderId);
		}
	}
}
