
using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;
using LogStore.Domain.Shared;
using LogStore.Domain.Validators;
using MediatR;

namespace LogStore.Domain.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, IResultResponse<AddOrderResponse>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        private readonly IOrderUserService _orderUserService;

        public AddOrderHandler(
            IUnitOfWork uow,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IProductService productService,
            IOrderUserService orderUserService
        )
        {
            _uow = uow;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productService = productService;
            _orderUserService = orderUserService;
        }

        public async Task<IResultResponse<AddOrderResponse>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            ResultResponse<AddOrderResponse> result = new ResultResponse<AddOrderResponse>();

            var validator = await new AddOrderCommandValidator(_uow).ValidateAsync(request);

            if (!validator.IsValid)
            {
                result.AddMessage(validator.Errors);
                return result;
            }

            decimal orderValueTotal = await _productService.CalculateOrderTotalValue(request.OrderItems);
            Order order = await _orderService.AddOrder(orderValueTotal);

            foreach (var item in request.OrderItems)
            {
                decimal OrderItemvalueTotal = await _productService.CalculateOrderItemTotalValue(item);
                await _orderItemService.AddOrderItem(order, item, OrderItemvalueTotal);   
            }

            await _uow.SaveChange();

            await _orderUserService.Add(order.OrderID, request.UserID);

            result.Value = null;

            return result;
        } 
    }
}