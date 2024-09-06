using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IBrendRepository
	{
		Task<List<Brend>> GetListAsync();
	}
}