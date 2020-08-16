using LogStore.Domain.Services;
using LogStore.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogStore.Domain.Configuration
{
    public static class DomainConfiguration
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IOrderItemService, OrderItemService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IOrderUserService, OrderUserService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IOrderAddressService, OrderAddressService>();
        }
    }
}