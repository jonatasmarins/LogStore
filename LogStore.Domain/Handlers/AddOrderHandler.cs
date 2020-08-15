using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Shared;
using LogStore.Domain.Validators;
using MediatR;

namespace LogStore.Domain.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand, IResultResponse<Order>>
    {
        private readonly IUnitOfWork _uow;
        public AddOrderHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IResultResponse<Order>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            ResultResponse<Order> result = new ResultResponse<Order>();

            var validator = await new AddOrderCommandValidator(_uow).ValidateAsync(request);

            if (!validator.IsValid)
            {
                result.AddMessage(validator.Errors);
            }

            Order order = await ConvertCommandToEntity(request);
            
            await _uow.OrderRepository.Add(order);

            return result;
        }

        private async Task<Order> ConvertCommandToEntity(AddOrderCommand command)
        {

            Order order = new Order();

            order.CreateDate = DateTime.Now;

            foreach (var item in command.OrderItems)
            {
                var products = new List<Product>();

                foreach (var itemProduct in item.Products)
                {
                    Product product = new Product(itemProduct.ProductID);
                    products.Add(product);
                }

                decimal valueTotalItem = await CalculateProductsValue(item.Products);

                OrderItem orderItem = new OrderItem(
                    order.OrderID,
                    item.OrderItemTypeID,
                    item.Description,
                    valueTotalItem,
                    products
                );
            }


            return order;
        }

        private async Task<decimal> CalculateProductsValue(IList<ProductModel> Products)
        {
            decimal total = 0;

            foreach (var item in Products)
            {
                var product = await _uow.ProductRepository.GetProductById(item.ProductID);

                total =+ product.Value;
            }

            return total;
        }
    }
}