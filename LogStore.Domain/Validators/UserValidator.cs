using FluentValidation;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Validators
{
    public class UserValidator: AbstractValidator<User>
    {
        private const int QTD_MAX_ITEM = 10;
        public string MessageNumberInvalid = "O Número não pode ser negativo ou zero";
        public string MessageValueRequired = "O {0} é obrigatório";

        public UserValidator()
        {            
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Nome"));

            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Email"));

            RuleFor(x => x.Address).SetValidator(new AddressValidator());
        }
    }
}