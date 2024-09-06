using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IOrderRepository
	{
		Task<List<Order>> GetListAsync();
	}
}