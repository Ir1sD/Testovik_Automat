using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface ICoinService
    {
        Task<List<Coin>> GetListAsync();
    }
}