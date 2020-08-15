using LogStore.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LogStore.Data.Configuration
{
    public static class DataConfig
    {
        public static void Config(this IServiceCollection services, IConfiguration configuration)
        { 
            // services.AddTransient<IRoleRepository, RoleRepository>();
            // services.AddTransient<IGroupRepository, GroupRepository>();

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