using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IBrendService
    {
        Task<List<Brend>> GetListAsync();
        Task<Brend> GetById(long id);

	}
}