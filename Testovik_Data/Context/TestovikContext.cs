using Microsoft.EntityFrameworkCore;

namespace Testovik_Data.Context
{
	public class TestovikContext : DbContext
	{
		public TestovikContext(DbContextOptions<TestovikContext> options)
		   : base(options)
		{

		}
	}
}
