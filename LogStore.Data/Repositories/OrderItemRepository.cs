using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly DataContext _dataContext;

        public OrderItemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<IList<OrderItem>> Add(IList<OrderItem> items)
        {
            await _dataContext.AddRangeAsync(items);
            return items;
        }
    }
}