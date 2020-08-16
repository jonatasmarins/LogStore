using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class OrderUserConfigurationBuilder: IEntityTypeConfiguration<OrderUser>
    {
        public void Configure(EntityTypeBuilder<OrderUser> builder)
        {
            builder.ToTable("OrderUser");

            builder.Property(x => x.OrderUserID).ValueGeneratedOnAdd();
        }
    }
}