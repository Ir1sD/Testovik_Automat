using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class OrderService : IOrderService
	{
		private readonly IOrderRepository orderRepository;
		private readonly IOrderWithUserRepository orderWithUserRepository;
		public OrderService(IOrderRepository orderRepository, IOrderWithUserRepository orderWithUserRepository)
		{
			this.orderRepository = orderRepository;
			this.orderWithUserRepository = orderWithUserRepository;
		}

        /// <summary>
        /// Возвращает список заказов
        /// </summary>
        /// <returns></returns>
        public async Task<List<Order>> GetListAsync()
		{
			return await orderRepository.GetListAsync();
		}

        /// <summary>
        /// Добаляет новый заказ
        /// </summary>
        /// <param name="sum">Сумма заказа</param>
        /// <returns>Id нового заказа</returns>
        public async Task Add(int sum , List<Tovar> tovars , int[] counts)
		{
			var id = await orderRepository.Add(sum);
			await orderWithUserRepository.AddRange(tovars, counts, id);
		}
	}

}
