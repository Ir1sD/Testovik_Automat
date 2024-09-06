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
	}
}
