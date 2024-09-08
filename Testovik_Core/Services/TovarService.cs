using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{
    public class TovarService : ITovarService
	{
		private readonly ITovarRepository tovarRepository;

		public TovarService(ITovarRepository tovarRepository)
		{
			this.tovarRepository = tovarRepository;
		}

        /// <summary>
        /// Возвращает список товаров
        /// </summary>
        /// <returns></returns>
        public async Task<List<Tovar>> GetListAsync()
		{
			return await tovarRepository.GetListAsync();
		}

		/// <summary>
		/// Возвращает список товаров по id бренда
		/// </summary>
		/// <param name="brendId">Id бренда</param>
		/// <returns></returns>
		public async Task<List<Tovar>> GetListWithFilterAsync(int brendId)
		{
			var list = await GetListAsync();

			if(brendId == 0)
			{
				return list;
			}

			list = list.Where(c => c.IdBrend == brendId).ToList();
			return list;
		}

		/// <summary>
		/// Возращает список товаров по списку id
		/// </summary>
		/// <param name="ids">Список id</param>
		/// <returns></returns>
		public async Task<List<Tovar>> GetListWithListId(long[] ids)
		{
			var list = await GetListAsync();

			var model = new List<Tovar>();

			foreach (var id in ids)
			{
				var item = list.FirstOrDefault(c => c.Id == id);

				if(item != null)
				{
					model.Add(item);
				}
			}

			return model;
		}

        /// <summary>
        /// Обновляет информацию о товаре
        /// </summary>
        /// <param name="tovar">Объект товара</param>
        /// <returns></returns>
        public async Task Update(Tovar tovar)
		{
			await tovarRepository.Update(tovar);
		}

        /// <summary>
        /// Добавляет товар
        /// </summary>
        /// <param name="tovar">Обхект товара</param>
        /// <returns></returns>
        public async Task Add(Tovar tovar)
        {
			await tovarRepository.Add(tovar);
        }
    }
}
