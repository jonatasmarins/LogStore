using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class AddressConfigurationBuilder: IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.Property(x => x.AddressID).ValueGeneratedOnAdd();

            // builder.Property(x => x.City).IsRequired();
            // builder.Property(x => x.Neighborhood).IsRequired();
            // builder.Property(x => x.Number).IsRequired();
            // builder.Property(x => x.Street).IsRequired();
        }
    }
}