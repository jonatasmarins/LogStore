using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;

namespace LogStore.Domain.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _uow;
        public AddressService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        
        public async Task<Address> Add(string street, string city, int number, string neighborhood)
        {
            var result = await _uow.AddressRepository.Add(
                new Address(street, city, number, neighborhood)
            );

            await _uow.SaveChange();

            return result;
        }
    }
}