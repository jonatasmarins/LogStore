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
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderItemTypeRepository, OrderItemTypeRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DataContext>(builder =>
            {
                builder.UseSqlite("Data Source=LogStoreDbTest.db");
            });
        }
    }
}