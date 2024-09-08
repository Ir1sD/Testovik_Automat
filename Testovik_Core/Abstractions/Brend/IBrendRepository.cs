using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
	public interface IBrendRepository
	{
        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        Task<List<Brend>> GetListAsync();
	}
}