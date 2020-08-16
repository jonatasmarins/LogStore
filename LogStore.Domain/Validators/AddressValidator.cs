using FluentValidation;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Validators
{
    public class AddressValidator: AbstractValidator<Address>
    {
        private const int QTD_MAX_ITEM = 10;
        public string MessageNumberInvalid = "Número não pode ser negativo ou zero";
        public string MessageValueRequired = "{0} é obrigatório";

        public AddressValidator()
        {            
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.City)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Cidade"));

            RuleFor(x => x.Neighborhood)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Bairro"));

            RuleFor(x => x.Number)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Número"))
                    .GreaterThan(0).WithMessage(MessageNumberInvalid);

            RuleFor(x => x.Street)
                    .NotEmpty().WithMessage(string.Format(MessageValueRequired, "Rua"));
        }
    }
}