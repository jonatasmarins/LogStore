using System.Threading.Tasks;
using FluentValidation;
using LogStore.Domain.Commands;
using LogStore.Domain.Repositories.Uow;

namespace LogStore.Domain.Validators
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        private const int QTD_MAX_ITEM = 10;
        public string MessageLessOneItem = "É obrigatório ao menos um item no Pedido";
        public string MessageMoreTenItem = $"A quantidade máxima é de {QTD_MAX_ITEM} itens por pedido";
        public string MessageQuantidadeProductRequired = "É obrigatório mais de um sabor";

        private readonly IUnitOfWork _unitOfWork;
        public AddOrderCommandValidator(IUnitOfWork unitOfWork)
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
        }

        private async Task<bool> QuantityProductValidate(long idOrderItemTypeID, int quantity)
        {
            return await _unitOfWork.OrderItemTypeRepository.IsQuantityProductValid(idOrderItemTypeID, quantity);
        }
    }
}