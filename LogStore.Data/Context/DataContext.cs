using LogStore.Data.ConfigurationBuilder;
using LogStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LogStore.Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderSubItem> OrderSubItems { get; set; }
        public DbSet<Product> Products { get; set; }

        public DataContext(DbContextOptions options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderItemConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new OrderSubItemConfigurationBuilder());
            modelBuilder.ApplyConfiguration(new ProductConfigurationBuilder());

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

            // modelBuilder.Entity<Group>()
            //     .HasData(new[]
            //     {
            //         new Group()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Grupo da GGIA",
            //             Id = 1,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "G_ES5_ATENDIMENTO_ITI_GGIA"
            //         },
            //         new Group()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Grupo de negócios",
            //             Id = 2,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "G_ES5_ATENDIMENTO_ITI_NEG"
            //         },
            //         new Group()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Grupo da GGIA (dev)",
            //             Id = 3,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "G_ES5_ATENDIMENTO_ITI_GGIA_DEV"
            //         },
            //         new Group()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Grupo de negócios (dev)",
            //             Id = 4,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "G_ES5_ATENDIMENTO_ITI_NEG_DEV"
            //         }
            //                 });
            // modelBuilder.Entity<Role>()
            //     .HasData(new[]
            //     {
            //         new Role()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Role que permite acessar a ferramenta de gestão de acessos",
            //             Id = 1,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "ROLESAPI_ACESSAR"
            //         },
            //         new Role()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Role que permite editar grupos",
            //             Id = 2,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "ROLESAPI_GRUPOS_EDITAR"
            //         },
            //         new Role()
            //         {
            //             Active = true,
            //             CreateDate = DateTime.Now,
            //             Creator = "system (auto generated)",
            //             Description = "Role que permite editar roles",
            //             Id = 3,
            //             LastChangeCreator = "system (auto generated)",
            //             LastChangeDate = DateTime.Now,
            //             Name = "ROLESAPI_ROLES_EDITAR"
            //         }
            //     });
            // modelBuilder.Entity<GroupRoleRelationship>()
            //     .HasData(
            //         new[]
            //         {
            //             // GGIA
            //             new GroupRoleRelationship()
            //             {
            //                 CreateDate = DateTime.Now,
            //                 Creator = "system (auto generated)",
            //                 GroupId = 1,
            //                 RoleId = 1
            //             },
            //             new GroupRoleRelationship()
            //             {
            //                 CreateDate = DateTime.Now,
            //                 Creator = "system (auto generated)",
            //                 GroupId = 1,
            //                 RoleId = 2
            //             },
            //             // NEGÓCIO
            //             new GroupRoleRelationship()
            //             {
            //                 CreateDate = DateTime.Now,
            //                 Creator = "system (auto generated)",
            //                 GroupId = 2,
            //                 RoleId = 1
            //             },
            //             new GroupRoleRelationship()
            //             {
            //                 CreateDate = DateTime.Now,
            //                 Creator = "system (auto generated)",
            //                 GroupId = 2,
            //                 RoleId = 3
            //             }
            //         }
            //     );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}