using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _context;
        public OrderRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}