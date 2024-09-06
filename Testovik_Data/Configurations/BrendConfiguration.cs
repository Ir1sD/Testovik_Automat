using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testovik_Data.Entities;

namespace Testovik_Data.Configurations
{
	public class BrendConfiguration : IEntityTypeConfiguration<BrendEntity>
	{
		public void Configure(EntityTypeBuilder<BrendEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.ToTable("Brends");
		}
	}
}
