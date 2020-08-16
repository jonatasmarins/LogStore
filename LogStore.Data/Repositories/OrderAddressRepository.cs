using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class OrderAddressRepository : IOrderAddressRepository
    {
        private readonly DataContext _dataContext;

        public OrderAddressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<OrderAddress> Add(OrderAddress entity)
        {
            await _dataContext.AddAsync(entity);

            return entity;
        }
    }
}