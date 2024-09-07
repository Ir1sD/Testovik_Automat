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

		public async Task<List<Order>> GetListAsync()
		{
			return await orderRepository.GetListAsync();
		}

		public async Task Add(int sum , List<Tovar> tovars , int[] counts)
		{
			var id = await orderRepository.Add(sum);
			await orderWithUserRepository.AddRange(tovars, counts, id);
		}
	}

}
