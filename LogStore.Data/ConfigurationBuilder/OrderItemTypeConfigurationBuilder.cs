using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class OrderItemTypeConfigurationBuilder : IEntityTypeConfiguration<OrderItemType>
    {
        public void Configure(EntityTypeBuilder<OrderItemType> builder)
        {
            builder.ToTable("OrderItemType");

            builder.Property(x => x.OrderItemTypeID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.QuantityProduct).HasDefaultValue(1);
        }
    }
}