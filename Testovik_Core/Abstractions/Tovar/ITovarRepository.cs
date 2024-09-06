using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface ITovarRepository
	{
		Task<List<Tovar>> GetListAsync();
	}
}