using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;
using LogStore.Domain.Shared;
using LogStore.Domain.Validators;
using MediatR;

namespace LogStore.Domain.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, IResultResponse<Order>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IProductService _productService;
        public AddOrderHandler(
            IUnitOfWork uow,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IProductService productService
        )
        {
            _uow = uow;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _productService = productService;
        }

        public async Task<IResultResponse<Order>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            ResultResponse<Order> result = new ResultResponse<Order>();

            var validator = await new AddOrderCommandValidator(_uow).ValidateAsync(request);

            if (!validator.IsValid)
            {
                result.AddMessage(validator.Errors);
            }

            decimal orderValueTotal = await _productService.CalculateOrderTotalValue(request.OrderItems);
            Order order = await _orderService.AddOrder(request, orderValueTotal);

            foreach (var item in request.OrderItems)
            {
                decimal OrderItemvalueTotal = await _productService.CalculateOrderItemTotalValue(item);
                await _orderItemService.AddOrderItem(order, item, OrderItemvalueTotal);   
            }

            await _uow.SaveChange();

            result.Value = order;

            return result;
        } 
    }
}