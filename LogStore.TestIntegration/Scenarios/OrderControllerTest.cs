using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LogStore.Api;
using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;
using LogStore.TestIntegration.Fixtures;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestIntegration.Scenarios
{
    public class OrderControllerTest : ContextTest
    {        
        private readonly ITestOutputHelper _output;

        public OrderControllerTest(
            ITestOutputHelper output
        )
        {
            _output = output;
        }

        [Theory]
        [InlineData("/User")]
        public async Task GetOrdersCommand_ReturnsOkResponse(string url)
        {
            var response = await Client.GetAsync($"{url}?UserID=1");

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [InlineData("/WithOutUser")]
        public async Task GetOrderWithOutUserCommand_ReturnsBadRequest_NotFoundAddress(string url)
        {
            var response = await Client.GetAsync($"{url}?AddressID=1");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [InlineData("/WithOutUser")]
        public async Task GetOrderWithOutUserCommand_ReturnsOkResponse(string url)
        {
            var response = await Client.GetAsync($"{url}?AddressID=3");

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [InlineData("/User")]
        public async Task AddOrderCommand_ReturnsOkResponse(string url)
        {
            AddOrderCommand command = new AddOrderCommand();
            command.UserID = 1;
            command.OrderItems = new[] {
                new OrderItemModel() {
                    OrderItemTypeID = 2,
                    Description = "Remover Cebola",
                    Products = {1, 7}
                }
            };

            var jsonContent = JsonConvert.SerializeObject(command); 
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, contentString);

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [InlineData("/WithOutUser")]
        public async Task AddOrderWithOutUserCommand_ReturnsOkResponse(string url)
        {
            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.City = "Campinas";
            command.Neighborhood = "Jd.Guarani";
            command.Number = 100;
            command.Street = "Jose Augusto";
            command.OrderItems = new[] {
                new OrderItemModel() {
                    OrderItemTypeID = 2,
                    Description = "Remover Cebola",
                    Products = {6, 2}
                }
            };

            var jsonContent = JsonConvert.SerializeObject(command); 
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(url, contentString);

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }
    }
}