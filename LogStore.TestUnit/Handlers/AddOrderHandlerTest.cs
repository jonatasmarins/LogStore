using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Handlers;
using LogStore.Domain.Models;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Validators;
using LogStore.TestUnit.Factories;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Handlers
{
    public class AddOrderHandlerTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly AddOrderCommandValidator _validator;
        private readonly AddOrderHandler _handler;

        public AddOrderHandlerTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _validator = new AddOrderCommandValidator(_uow.Object);
            _handler = new AddOrderHandler(_uow.Object);
        }

        [Fact]
        public async Task ItShouldReturnSuccess()
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(true);
            _uow.Setup(x => x.OrderRepository.Add(It.IsAny<Order>())).ReturnsAsync(OrderRepositoryFake.OrderValid());
            _uow.Setup(x => x.ProductRepository.GetProductById(It.IsAny<long>())).ReturnsAsync(ProductRepositoryFake.GetById());
            
            AddOrderCommand command = new AddOrderCommand();
            command.OrderItems.Add(new OrderItemModel() {
                Description = "",
                OrderItemTypeID = 1,
                Products = new[] {
                    new ProductModel() { ProductID = 1 },
                    new ProductModel() { ProductID = 1 }
                }
            });

            var result = await _handler.Handle(command, CancellationToken.None);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item);
            }

            Assert.True(result.Success);
        }
    }
}