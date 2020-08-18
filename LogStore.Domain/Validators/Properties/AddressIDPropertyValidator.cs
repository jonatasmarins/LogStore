using System.Threading.Tasks;
using FluentValidation;
using LogStore.Domain.Repositories.Uow;

namespace LogStore.Domain.Validators.Properties
{
    public class AddressIDPropertyValidator: AbstractValidator<long>
    {
        private readonly IUnitOfWork _uow;
        public string MessageAddressIdIsRequried = "É obrigatório informar o endereço";
        public string MessageAddressNotFound = "Endereço não encontrado";

        public AddressIDPropertyValidator(IUnitOfWork uow)
        {
            _uow = uow;
            
            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x)
                .NotEmpty().WithMessage(MessageAddressIdIsRequried)
                .MustAsync((id, cancelation) => IsExist(id)).WithMessage(MessageAddressNotFound);
        }

        public async Task<bool> IsExist(long addressId) {
            var user = await _uow.OrderAddressRepository.GetByAddressId(addressId);
            return (user != null);
        }
    }
}