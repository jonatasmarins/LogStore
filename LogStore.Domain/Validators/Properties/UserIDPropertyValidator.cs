using System.Threading.Tasks;
using FluentValidation;
using LogStore.Domain.Repositories.Uow;

namespace LogStore.Domain.Validators.Properties
{
    public class UserIDPropertyValidator : AbstractValidator<long>
    {
        private readonly IUnitOfWork _uow;
        public string MessageUserIdIsRequried = "É obrigatório informar o usuário";
        public string MessageUserNotFound = "Usuário não encontrado";

        public UserIDPropertyValidator(IUnitOfWork uow)
        {
            _uow = uow;
            
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x)
                .NotEmpty().WithMessage(MessageUserIdIsRequried)
                .MustAsync((id, cancelation) => IsExist(id)).WithMessage(MessageUserNotFound);
        }

        public async Task<bool> IsExist(long userId) {
            var user = await _uow.UserRepository.GetById(userId);
            return (user != null);
        }
    }
}