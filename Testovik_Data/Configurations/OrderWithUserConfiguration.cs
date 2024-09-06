using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testovik_Data.Entities;


namespace Testovik_Data.Configurations
{
	public class OrderWithUserConfiguration : IEntityTypeConfiguration<OrderWithUserEntity>
	{
		public void Configure(EntityTypeBuilder<OrderWithUserEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.ToTable("OrdersWithUsers");

		}
	}
}
