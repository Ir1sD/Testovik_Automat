using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testovik_Data.Entities;

namespace Testovik_Data.Configurations
{
	public class TovarConfigurations : IEntityTypeConfiguration<TovarEntity>
	{
		public void Configure(EntityTypeBuilder<TovarEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.ToTable("Tovars");

			builder.HasOne(e => e.Brend)
				.WithMany(e => e.Tovars)
				.HasForeignKey(e => e.IdBrend)
				.IsRequired();
		}
	}
}
