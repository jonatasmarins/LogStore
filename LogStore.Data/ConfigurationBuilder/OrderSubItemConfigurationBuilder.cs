using LogStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class OrderSubItemConfigurationBuilder : IEntityTypeConfiguration<OrderSubItem>
    {
        public void Configure(EntityTypeBuilder<OrderSubItem> builder)
        {
            builder.ToTable("OrderSubItem");

            builder.Property(x => x.OrderSubItemID).ValueGeneratedOnAdd();
        }
    }
}