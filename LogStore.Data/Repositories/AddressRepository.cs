using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogStore.Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _dataContext;

        public AddressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Address> Add(Address entity)
        {
            await _dataContext.AddAsync(entity);
            
            return entity;
        }

        public async Task<Address> GetById(long addressaID)
        {
            return await _dataContext.Addresses.Where(x => x.AddressID == addressaID).FirstOrDefaultAsync();
        }
    }
}