using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface ICoinService
    {
        Task<List<Coin>> GetListAsync();
        Task AddRange(int i1, int i2, int i5, int i10);

	}
}