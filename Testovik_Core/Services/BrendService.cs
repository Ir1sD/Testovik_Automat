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
	}
}
