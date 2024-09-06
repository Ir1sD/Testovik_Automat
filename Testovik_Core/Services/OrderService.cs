using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class OrderService : IOrderService
	{
		private readonly IOrderRepository orderRepository;

		public OrderService(IOrderRepository orderRepository)
		{
			this.orderRepository = orderRepository;
		}

		public async Task<List<Order>> GetListAsync()
		{
			return await orderRepository.GetListAsync();
		}
	}

}
