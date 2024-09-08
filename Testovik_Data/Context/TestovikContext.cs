using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Testovik_Data.Entities;

namespace Testovik_Data.Context
{
	public class TestovikContext : DbContext
	{
		public TestovikContext(DbContextOptions<TestovikContext> options)
		   : base(options)
		{
			
		}

		public DbSet<TovarEntity> Tovars { get; set; }
		public DbSet<BrendEntity> Brends { get; set; }
		public DbSet<CoinEntity> Coins { get; set; }
		public DbSet<OrderEntity> Orders { get; set; }
		public DbSet<OrderWithUserEntity> OrdersWithUsers { get; set; }
		public DbSet<UserEntity> Users { get; set; }
	}
}
