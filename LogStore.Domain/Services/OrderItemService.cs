using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Models;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;

namespace LogStore.Domain.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _uow;
        public OrderItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Order> AddOrderItem(Order order, OrderItemModel item, decimal valueTotalItem)
        {
            var products = new List<OrderSubItem>();

            foreach (var produID in item.Products)
            {
                OrderSubItem product = new OrderSubItem(order.OrderID, produID);
                products.Add(product);
            }

            OrderItem orderItem = new OrderItem(
                order.OrderID,
                item.OrderItemTypeID,
                item.Description,
                valueTotalItem,
                products
            );

            order.Items.Add(orderItem);

            await _uow.OrderItemRepository.Add(order.Items);

            return order;
        }
    }
}