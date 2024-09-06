using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IOrderWithUserRepository
	{
		Task<List<OrderWithUser>> GetListAsync();
	}
}