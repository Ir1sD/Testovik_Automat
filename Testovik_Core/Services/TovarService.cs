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

		public async Task<List<Tovar>> GetListAsync()
		{
			return await tovarRepository.GetListAsync();
		}

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
	}
}
