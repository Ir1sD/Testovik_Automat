using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface ICoinRepository
	{
		Task<List<Coin>> GetListAsync();
	}
}