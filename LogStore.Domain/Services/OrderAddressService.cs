using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;

namespace LogStore.Domain.Services
{
    public class OrderAddressService : IOrderAddressService
    {
        private readonly IUnitOfWork _uow;
        public OrderAddressService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<OrderAddress> Add(long orderID, long addressID)
        {
            var result = await _uow.OrderAddressRepository.Add(
                new OrderAddress(orderID, addressID)
            );

            await _uow.SaveChange();

            return result;
        }
    }
}