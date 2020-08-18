using System.Net.Http;
using LogStore.Api;
using LogStore.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LogStore.TestIntegration.Fixtures
{
    public class ContextTest
    {
        public HttpClient Client { get; set; }        

        public ContextTest()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    builder.ConfigureServices(service => {
                        service.RemoveAll(typeof(DataContext));
                        service.AddDbContext<DataContext>(option => {
                            option.UseInMemoryDatabase("TestDb");
                        });
                    });
                });

            Client = appFactory.CreateClient();
        }
    }
}