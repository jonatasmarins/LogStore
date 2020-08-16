using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class OrderUserRepository : IOrderUserRepository
    {
        private readonly DataContext _context;
        public OrderUserRepository(DataContext context)
        {
            _context = context;
        }
        
        public async Task<OrderUser> Add(OrderUser entity)
        {
            await _context.OrderUsers.AddAsync(entity);

            return entity;
        }
    }
}