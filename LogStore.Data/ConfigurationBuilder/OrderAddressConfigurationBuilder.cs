using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class OrderAddressConfigurationBuilder: IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.ToTable("OrderAddress");

            builder.Property(x => x.OrderAddressID).ValueGeneratedOnAdd();
        }
    }
}