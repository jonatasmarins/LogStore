using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Validators;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;

namespace LogStore.Domain.Validators
{
    public class AddOrderWithOutUserCommandValidator: AbstractValidator<AddOrderWithOutUserCommand>
    {
        private const int QTD_MAX_ITEM = 10;
        public string MessageLessOneItem = "É obrigatório ao menos um item no Pedido";
        public string MessageMoreTenItem = $"A quantidade máxima é de {QTD_MAX_ITEM} itens por pedido";
        public string MessageQuantidadeProductRequired = "É obrigatório mais de um sabor";
        public string MessageUserIdIsRequried = "É obrigatório informar o usuário";

        private readonly IUnitOfWork _unitOfWork;
        public AddOrderWithOutUserCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CascadeMode = CascadeMode.Stop;

            RuleFor(x => x.OrderItems.Count)
                    .GreaterThan(0).WithMessage(MessageLessOneItem)
                    .LessThan(10).WithMessage(MessageMoreTenItem);

            RuleForEach(x => x.OrderItems).ChildRules(orderItem =>
            {
                orderItem.RuleFor(item => item)
                    .MustAsync(async (item, cancelation) =>
                        await QuantityProductValidate(item.OrderItemTypeID, item.Products.Count)
                    ).WithMessage(MessageQuantidadeProductRequired);
            });

            RuleFor(x => x).Custom((item, context) => AddressValid(item, context));
        }

        private async Task<bool> QuantityProductValidate(long idOrderItemTypeID, int quantity)
        {
            return await _unitOfWork.OrderItemTypeRepository.IsQuantityProductValid(idOrderItemTypeID, quantity);
        }

        private void AddressValid(AddOrderWithOutUserCommand item, CustomContext context) {
            Address address = new Address(
                item.Street,
                item.City,
                item.Number,
                item.Neighborhood
            );

            AddressValidator validator = new AddressValidator();
            var result = validator.Validate(address);

            if(!result.IsValid) {
                foreach (var error in result.Errors)
                {
                    context.AddFailure(error);
                }
            }
        }
    }
}