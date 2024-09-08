using Testovik_Core.Models;

namespace Testovik_Core.Abstractions
{
    public interface IBrendService
    {
        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        Task<List<Brend>> GetListAsync();

        /// <summary>
		/// Возвращает бренд по Id
		/// </summary>
		/// <param name="id">Идентификатор</param>
        Task<Brend> GetById(long id);

	}
}