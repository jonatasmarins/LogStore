using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Validators;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Validators
{
    public class AddOrderCommandValidatorTest
    {
        private readonly ITestOutputHelper _output;
        private readonly AddOrderCommandValidator _validator;
        private readonly Mock<IUnitOfWork> _uow;

        public AddOrderCommandValidatorTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _validator = new AddOrderCommandValidator(_uow.Object);
        }

        [Fact]
        public void ItShouldReturnErrorWhenQtdOrderIsLessOne()
        {
            AddOrderCommand command = new AddOrderCommand();

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
            AddOrderCommand command = new AddOrderCommand();

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

            AddOrderCommand command = new AddOrderCommand();
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

            AddOrderCommand command = new AddOrderCommand();
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