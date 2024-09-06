using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testovik_Data.Entities;

namespace Testovik_Data.Configurations
{
	public class CoinConfiguration : IEntityTypeConfiguration<CoinEntity>
	{
		public void Configure(EntityTypeBuilder<CoinEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.ToTable("Coins");
		}
	}
}
