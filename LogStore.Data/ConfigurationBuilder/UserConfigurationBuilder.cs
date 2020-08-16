using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogStore.Data.ConfigurationBuilder
{
    public class UserConfigurationBuilder: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(x => x.UserID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired();
            
            builder.Property(x => x.Email).IsRequired();
        }
    }
}