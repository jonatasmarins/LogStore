using System;
using LogStore.Data.ConfigurationBuilder;
using LogStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogStore.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderItemType> OrderItemTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        // public DbSet<Address> Addresses { get; set; }
        // public DbSet<User> Users { get; set; }
        // public DbSet<OrderAddress> OrderAddresses { get; set; }
        // public DbSet<OrderUser> OrderUsers { get; set; }


        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderItemTypeConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderItemConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderSubItemConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new ProductConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new AddressConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new UserConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderAddressConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderUserConfigurationBuilder());

            SeedInitialData(modelBuilder);
            
            base.OnModelCreating(modelBuilder);
        }
        
        private static void SeedInitialData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(new[] {
                    new Product() {
                        ProductID = 1,
                        Name = "3 Queijos",
                        Description = "Molho de tomate coberto por três tipo de queijo",
                        Value = 50
                    },
                    new Product() {
                        ProductID = 2,
                        Name = "Frango com Requeijão",
                        Description = "Molho de tomate coberto de frango com requeijão",
                        Value = 59.99M
                    },
                    new Product() {
                        ProductID = 3,
                        Name = "Mussarela",
                        Description = "Molho de tomate coberto por queijo mussarela",
                        Value = 42.50M
                    },
                    new Product() {
                        ProductID = 4,
                        Name = "Calabresa",
                        Description = "Molho de tomate coberto por calabresa e cebola",
                        Value = 42.50M
                    },
                    new Product() {
                        ProductID = 5,
                        Name = "Pepperoni",
                        Description = "Molho de tomate coberto por pepperoni",
                        Value = 55
                    },
                    new Product() {
                        ProductID = 6,
                        Name = "Portuguesa ",
                        Description = "Molho de tomate coberto por mussarela, pressunto, ovo e banco",
                        Value = 45
                    },
                    new Product() {
                        ProductID = 7,
                        Name = "Veggie  ",
                        Description = "Molho de tomate coberto por mussarela, Tomate e ervilha",
                        Value = 59.99M
                    },
                });

            modelBuilder.Entity<OrderItemType>()
                .HasData(
                    new[] {
                        new OrderItemType() {
                            OrderItemTypeID = 1,
                            Name = "Pizza Grande (8 Fatias)",
                            Description = "Pizza grande de 8 fatias com um único sabor"
                        },
                        new OrderItemType() {
                            OrderItemTypeID = 2,
                            Name = "Pizza Grande (8 Fatias) - 2 Sabores",
                            Description = "Pizza grande de 8 fatias com dois sabores",
                            QuantityProduct = 2
                        },
                        new OrderItemType() {
                            OrderItemTypeID = 3,
                            Name = "Pizza Broto (4 Fatias)",
                            Description = "Pizza grande de 4 fatias com um único sabor"
                        },
                        new OrderItemType() {
                            OrderItemTypeID = 4,
                            Name = "Pizza Broto (4 Fatias) - 2 Sabores",
                            Description = "Pizza grande de 4 fatias com dois sabaores",
                            QuantityProduct = 2
                        },
                    }
                );

            modelBuilder.Entity<Address>()
                .HasData(
                    new[] {
                        new Address() {
                            AddressID = 1,
                            City = "Indaiatuba",
                            Neighborhood = "Montreal",
                            Number = 5000,
                            Street = "Rua Monte Royal"
                        },
                        new Address() {
                            AddressID = 2,
                            City = "Campinas",
                            Neighborhood = "Nova Veneza",
                            Number = 3555,
                            Street = "Rua Palmeiras"
                        }
                    }
                );
            
            modelBuilder.Entity<User>()
                .HasData(new[] {
                    new User() {
                        UserID = 1,
                        DateCreate = DateTime.Now,
                        Email = "jose@aparecido.com",
                        Name = "Jose Aparecido",
                        Phone = "19996969999",
                        AddressID = 1
                    },
                    new User() {
                        UserID = 2,
                        DateCreate = DateTime.Now,
                        Email = "Maria@rita.com",
                        Name = "Maria Rita",
                        Phone = "19996969991",
                        AddressID = 2
                    }
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}