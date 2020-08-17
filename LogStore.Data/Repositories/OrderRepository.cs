using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogStore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
            return Task.FromResult(order);
        }

        public async Task<IList<Order>> GetByAddressId(long addressID)
        {
            var result = _context.Orders
                .Include(x => x.Items)
                    .ThenInclude(item => item.OrderItemType)
                .Include(x => x.Items)
                    .ThenInclude(item => item.Products) 
                    .ThenInclude(prod => prod.Product)               
                .Join(_context.OrderAddresses,
                    order => order.OrderID,
                    orderAddress => orderAddress.OrderID,
                    (order, orderAddress) => new { Order = order, OrderAddress = orderAddress })
                .Where(x => x.OrderAddress.AddressID == addressID)
                .Select(x => x.Order);

            return await result.ToListAsync();
        }

        public async Task<Order> GetById(long orderID)
        {
            return await _context.Orders.Where(x => x.OrderID == orderID).Include(x => x.Items).FirstOrDefaultAsync();
        }

        public async Task<IList<Order>> GetByUserId(long userID)
        {
            var result = _context.Orders
                .Include(x => x.Items)
                    .ThenInclude(item => item.OrderItemType)
                .Include(x => x.Items)
                    .ThenInclude(item => item.Products) 
                    .ThenInclude(prod => prod.Product)               
                .Join(_context.OrderUsers,
                    order => order.OrderID,
                    orderUser => orderUser.OrderID,
                    (order, orderUser) => new { Order = order, OrderUser = orderUser })
                .Where(x => x.OrderUser.UserID == userID)
                .Select(x => x.Order);

            return await result.ToListAsync();
        }
    }
}