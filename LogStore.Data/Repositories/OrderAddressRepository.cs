using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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

        public async Task<OrderAddress> GetByAddressId(long addressID)
        {
            return await _dataContext.OrderAddresses.Where(x => x.AddressID == addressID).FirstOrDefaultAsync();
        }
    }
}