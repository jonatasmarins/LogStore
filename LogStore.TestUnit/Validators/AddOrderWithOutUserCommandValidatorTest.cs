using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Validators;
using LogStore.TestUnit.DataGenerator;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Validators
{
    public class AddOrderWithOutUserCommandValidatorTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AddOrderWithOutUserCommandValidator _validator;
        private readonly Mock<IUnitOfWork> _uow;

        public AddOrderWithOutUserCommandValidatorTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _validator = new AddOrderWithOutUserCommandValidator(_uow.Object);
        }

        [Fact]
        public void ItShouldReturnErrorWhenQtdOrderIsLessOne()
        {
            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();

            var result = _validator.Validate(command);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ItShouldReturnErrorWhenQtdOrderIsMoreTen()
        {
            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();

            for (int i = 0; i < 10; i++)
            {
                command.OrderItems.Add(new OrderItemModel());
            }

            var result = _validator.Validate(command);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ItShouldReturnErrorWhenItemOrderTypeQuantityProductValidatorDiffValueInBase()
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(false);

            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.OrderItems.Add(
                new OrderItemModel()
                {
                    Description = "",
                    OrderItemTypeID = 2,
                    Products = { 1 }
                }
            );

            var result = _validator.Validate(command);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.False(result.IsValid);
        }

        [Theory]
        [MemberData(nameof(AddressRequestModelGenerate.GetData), MemberType = typeof(AddressRequestModelGenerate))]
        public void ItShouldReturnErrorWhenFieldIsRequired(AddressRequestModelFake request)
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(true);

            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.City = request.City;
            command.Neighborhood = request.Neighborhood;
            command.Number = request.Number;
            command.Street = request.Street;
            command.OrderItems.Add(
                new OrderItemModel()
                {
                    Description = "",
                    OrderItemTypeID = 2,
                    Products = { 1 }
                }
            );

            var result = _validator.Validate(command);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ItShouldSuccess()
        {
            _uow.Setup(x => x.OrderItemTypeRepository.IsQuantityProductValid(It.IsAny<long>(), It.IsAny<int>())).ReturnsAsync(true);

            AddOrderWithOutUserCommand command = new AddOrderWithOutUserCommand();
            command.OrderItems.Add(
                new OrderItemModel()
                {
                    Description = "",
                    OrderItemTypeID = 2,
                    Products = { 1 }
                }
            );

            var result = _validator.Validate(command);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.True(result.IsValid);
        }
    }
}