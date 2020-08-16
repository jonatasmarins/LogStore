using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class OrderSubItemConfigurationBuilder: IEntityTypeConfiguration<OrderSubItem>
    {
        public void Configure(EntityTypeBuilder<OrderSubItem> builder)
        {
            builder.ToTable("OrderSubItem");

            builder.Property(x => x.OrderSubItemID).ValueGeneratedOnAdd();

            builder.Property(x => x.OrderItemID).IsRequired();

            builder.Property(x => x.ProductID).IsRequired();
        }
    }
}