using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Validators.Properties;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace LogStore.TestUnit.Validators.Properties
{
    public class UserIDPropertyValidatorTest
    {
         private readonly ITestOutputHelper _output;
        private readonly UserIDPropertyValidator _validator;
        private readonly Mock<IUnitOfWork> _uow;

        public UserIDPropertyValidatorTest(ITestOutputHelper output)
        {
            _output = output;
            _uow = new Mock<IUnitOfWork>();
            _validator = new UserIDPropertyValidator(_uow.Object);
        }

        [Fact]
        public void ItShouldReturnErrorWhenUserNotFound()
        {       
            User user = null;
            _uow.Setup(x => x.UserRepository.GetById(It.IsAny<long>())).ReturnsAsync(user);
            
            var result = _validator.Validate(long.MaxValue);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.False(result.IsValid);
        }

        [Fact]
        public void ItShouldReturnSuccess()
        {       
            User user = new User();
            _uow.Setup(x => x.UserRepository.GetById(It.IsAny<long>())).ReturnsAsync(user);
            
            var result = _validator.Validate(long.MaxValue);

            foreach (var item in result.Errors)
            {
                _output.WriteLine(item.ErrorMessage);
            }

            Assert.True(result.IsValid);
        }
    }
}