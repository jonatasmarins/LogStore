using System;
using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;

namespace LogStore.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<Order> AddOrder(decimal totalValue)
        {
            Order order = new Order();
            order.CreateDate = DateTime.Now;
            order.Value = totalValue;

            return await _uow.OrderRepository.Add(order);
        }
    }
}