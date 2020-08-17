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
    public class AddOrderWithOutUserHandler: IRequestHandler<AddOrderWithOutUserCommand, IResultResponse>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        private readonly IAddressService _addressService;
        private readonly IOrderAddressService _orderaddressService;

        public AddOrderWithOutUserHandler(
            IUnitOfWork uow,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IProductService productService,
            IAddressService addressService,
            IOrderAddressService orderaddressService
        )
        {
            _uow = uow;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productService = productService;
            _addressService = addressService;
            _orderaddressService = orderaddressService;
        }
        
        public async Task<IResultResponse> Handle(AddOrderWithOutUserCommand request, CancellationToken cancellationToken)
        {
            ResultResponse result = new ResultResponse();

            var validator = await new AddOrderWithOutUserCommandValidator(_uow).ValidateAsync(request);

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

            var address = await _addressService.Add(request.Street, request.City, request.Number, request.Neighborhood);
            
            await _orderaddressService.Add(order.OrderID, address.AddressID);

            return result;
        }
    }
}