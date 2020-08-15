using LogStore.Data.Context;
using LogStore.Data.Repositories;
using LogStore.Data.Uow;
using LogStore.Domain.Repositories;
using LogStore.Domain.Repositories.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogStore.Data.Configuration
{
    public static class DataConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemTypeRepository, OrderItemTypeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DataContext>(builder =>
            {
                // var hostname = configuration["POSTGRES_DATABASE_ADDRESS"];
                // var database = configuration["POSTGRES_DATABASE"];
                // var username = configuration["POSTGRES_USER"];
                // var password = configuration["POSTGRES_PASSWORD"];
                // builder.UseNpgsql($"Host={hostname};Database={database};Username={username};Password={password}");
                // builder.UseNpgsql($"Host={hostname};Database={database};Username={username};Password={password}", builder =>
                // {
                //     builder.MigrationsAssembly("Roles.Api");
                // });
                builder.UseSqlite("Data Source=LogStoreDbTest.db");
            });
        }
    }
}