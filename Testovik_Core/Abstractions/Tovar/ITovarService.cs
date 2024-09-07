using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface ITovarService
    {
        Task<List<Tovar>> GetListAsync();
        Task<List<Tovar>> GetListWithFilterAsync(int brendId);
        Task<List<Tovar>> GetListWithListId(long[] ids);

	}
}