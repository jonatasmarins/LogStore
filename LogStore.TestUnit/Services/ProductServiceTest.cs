using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;
using LogStore.TestUnit.DataGenerator;
using LogStore.TestUnit.Factories;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Services
{
    public class ProductServiceTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly IProductService _productService;

        public ProductServiceTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _productService = new ProductService(_uow.Object);
        }

        [Theory]
        [MemberData(nameof(OrderItemModelGenerator.GetData), MemberType = typeof(OrderItemModelGenerator))]
        public async Task ItShouldCalculateValid(OrderItemModelData orderItemModel)
        {
            foreach (var item in orderItemModel.OrderItemModel.Products)
            {
                _uow.Setup(x => x.ProductRepository.GetProductById(item)).ReturnsAsync(ProductRepositoryFake.GetProduct(item));
            }

            var totalValue = await _productService.CalculateOrderItemTotalValue(orderItemModel.OrderItemModel);

            _output.WriteLine($"Valor Total calculado: {totalValue}");
            _output.WriteLine($"Valor Total: {orderItemModel.TotalValue}");

            Assert.Equal(orderItemModel.TotalValue, totalValue);
        }
    }
}