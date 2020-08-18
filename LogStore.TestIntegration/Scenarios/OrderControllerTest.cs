using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LogStore.Api;
using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;
using LogStore.TestIntegration.Constants;
using LogStore.TestIntegration.DataGenerators;
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
        [InlineData(1)]
        public async Task GetOrdersCommand_ReturnsOkResponse(long userId)
        {
            var response = await Client.GetAsync($"{PathURL.ORDER_USER}?UserID={userId}");

            var json = await response.Content.ReadAsStringAsync();
            _output.WriteLine(json);

            var result = response.EnsureSuccessStatusCode();
            
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetOrderWithOutUserCommand_ReturnsBadRequest_NotFoundAddress()
        {
            var response = await Client.GetAsync($"{PathURL.ORDER_ADDRESS}?AddressID=1");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(20)]
        public async Task GetOrderWithOutUserCommand_ReturnsOkResponse(long addressId)
        {
            var response = await Client.GetAsync($"{PathURL.ORDER_ADDRESS}?AddressID={addressId}");

            var json = await response.Content.ReadAsStringAsync();
            _output.WriteLine(json);

            if(response.IsSuccessStatusCode) {
                var result = response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);
            } else {
                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
                json.Should().Be(json, "[\"Endereço não encontrado\"]");
                _output.WriteLine("Verifique se foi executado os métodos de adicionar");
            }
        }

        [Theory]
        [MemberData(nameof(AddOrderCommandDataGenerator.GetData), MemberType = typeof(AddOrderCommandDataGenerator))]
        public async Task AddOrderCommand_ReturnsOkResponse(AddOrderCommand command)
        {
            var jsonContent = JsonConvert.SerializeObject(command); 
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(PathURL.ORDER_USER, contentString);

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }

        [Theory]
        [MemberData(nameof(AddOrderWithOutUserCommandDataGenerator.GetData), MemberType = typeof(AddOrderWithOutUserCommandDataGenerator))]
        public async Task AddOrderWithOutUserCommand_ReturnsOkResponse(AddOrderWithOutUserCommand command)
        {
            var jsonContent = JsonConvert.SerializeObject(command); 
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await Client.PostAsync(PathURL.ORDER_ADDRESS, contentString);

            var result = response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();

            _output.WriteLine(json);
        }
    }
}