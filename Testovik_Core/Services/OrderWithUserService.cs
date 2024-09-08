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

		public async Task<List<OrderWithUser>> GetListAsync()
		{
			return await orderWithUserRepository.GetListAsync();
		}

		public async Task<List<OrderWithUser>> GetByIdOrder(long orderId)
		{
			return await orderWithUserRepository.GetByIdOrder(orderId);
		}
	}
}
