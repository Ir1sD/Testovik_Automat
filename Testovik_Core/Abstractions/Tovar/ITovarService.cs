using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface ITovarService
    {
        Task<List<Tovar>> GetListAsync();
    }
}