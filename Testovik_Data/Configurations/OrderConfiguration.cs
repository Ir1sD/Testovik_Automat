using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Testovik_Data.Entities;

namespace Testovik_Data.Configurations
{
	public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
	{
		public void Configure(EntityTypeBuilder<OrderEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Id)
				.ValueGeneratedOnAdd();

			builder.ToTable("Orders");

			builder.HasMany(e => e.OrdersWithUsersEntities)
				.WithOne(e => e.Order)
				.HasForeignKey(e => e.IdOrder)
				.IsRequired();
		}
	}
}
