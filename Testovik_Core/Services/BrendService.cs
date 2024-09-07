using Testovik_Core.Abstractions;
using Testovik_Core.Models;

namespace Testovik_Core.Services
{

    public class BrendService : IBrendService
	{
		private readonly IBrendRepository brendRepository;

		public BrendService(IBrendRepository brendRepository)
		{
			this.brendRepository = brendRepository;
		}

		public async Task<List<Brend>> GetListAsync()
		{
			return await brendRepository.GetListAsync();
		}

		public async Task<Brend> GetById(long id)
		{
			var list = await GetListAsync();

			return list.FirstOrDefault(c => c.Id == id);
		}
	}
}
