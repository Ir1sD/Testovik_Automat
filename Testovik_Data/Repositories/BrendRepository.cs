using Microsoft.EntityFrameworkCore;
using Testovik_Data.Context;
using Testovik_Data.Entities;
using Testovik_Core.Models;


namespace Testovik_Data.Repositories
{
	public class BrendRepository
	{
		private TestovikContext _context;

		public BrendRepository(TestovikContext context)
		{
			_context = context;
		}

	}
}
