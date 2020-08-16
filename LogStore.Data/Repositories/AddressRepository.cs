using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

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
    }
}