using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Handlers;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;
using LogStore.Domain.Validators;
using LogStore.TestUnit.DataGenerator;
using LogStore.TestUnit.Factories;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Handlers
{
    public class AddOrderWithOutUserHandlerTest
    {
        private readonly ITestOutputHelper _output;
        private readonly Mock<IUnitOfWork> _uow;
        private readonly AddOrderWithOutUserCommandValidator _validator;
        private readonly AddOrderWithOutUserHandler _handler;
        private readonly Mock<IOrderService> _orderService;
        private readonly Mock<IOrderItemService> _orderItemService;
        private readonly Mock<IProductService> _productService;
        private readonly Mock<IAddressService> _AddresService;
        private readonly Mock<IOrderAddressService> _orderAddresService;

        public AddOrderWithOutUserHandlerTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _validator = new AddOrderWithOutUserCommandValidator(_uow.Object);

            _orderService = new Mock<IOrderService>();
            _orderItemService = new Mock<IOrderItemService>();
            _productService = new Mock<IProductService>();
            _orderAddresService = new Mock<IOrderAddressService>();
            _AddresService = new Mock<IAddressService>();

            _handler = new AddOrderWithOutUserHandler(
                _uow.Object, 
                _orderService.Object,
                _orderItemService.Object,
                _productService.Object,
                _AddresService.Object,
                _orderAddresService.Object
            );
        }

        [Fact]
        public async Task ItShouldReturnSuccess()
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(true);
            _uow.Setup(x => x.OrderRepository.Add(It.IsAny<Order>())).ReturnsAsync(OrderRepositoryFake.OrderValid());
            _uow.Setup(x => x.ProductRepository.GetProductById(It.IsAny<long>())).ReturnsAsync(ProductRepositoryFake.GetById());
            
            _orderService.Setup(x => x.AddOrder(It.IsAny<decimal>())).ReturnsAsync(OrderRepositoryFake.OrderValid());
            _AddresService.Setup(x => x.Add(It.IsAny<string>(),It.IsAny<string>(),It.IsAny<int>(), It.IsAny<string>())).ReturnsAsync(AddressRepositoryFake.GetFirstOrDefaultValid());
            
            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.City = "São Paulo";
            command.Neighborhood = "Madalena";
            command.Number= 1;
            command.Street = "Tuiuti";
            command.OrderItems.Add(new OrderItemModel() {
                Description = "",
                OrderItemTypeID = 1,
                Products = {1 , 2}
            });

            var result = await _handler.Handle(command, CancellationToken.None);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item);
            }

            Assert.True(result.Success);
        }

        [Theory]
        [MemberData(nameof(AddressRequestModelGenerate.GetData), MemberType = typeof(AddressRequestModelGenerate))]
        public async Task ItShouldReturnErrorWhenFieldIsRequired(AddressRequestModelFake request)
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(true);
            _uow.Setup(x => x.OrderRepository.Add(It.IsAny<Order>())).ReturnsAsync(OrderRepositoryFake.OrderValid());
            _uow.Setup(x => x.ProductRepository.GetProductById(It.IsAny<long>())).ReturnsAsync(ProductRepositoryFake.GetById());
            
            _orderService.Setup(x => x.AddOrder(It.IsAny<decimal>())).ReturnsAsync(OrderRepositoryFake.OrderValid());
            
            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.City = request.City;
            command.Neighborhood = request.Neighborhood;
            command.Number= request.Number;
            command.Street = request.Street;
            command.OrderItems.Add(new OrderItemModel() {
                Description = "",
                OrderItemTypeID = 1,
                Products = {1 , 2}
            });

            var result = await _handler.Handle(command, CancellationToken.None);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item);
            }

            Assert.False(result.Success);
        }
    }
}