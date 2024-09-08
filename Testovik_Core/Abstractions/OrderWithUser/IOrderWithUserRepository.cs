using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IOrderWithUserRepository
	{
		Task<List<OrderWithUser>> GetListAsync();
		Task AddRange(List<Tovar> tovars, int[] counts, long idOrder);
		Task<List<OrderWithUser>> GetByIdOrder(long orderId);

    }
}