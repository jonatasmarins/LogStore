using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Services.Interfaces;

namespace LogStore.Domain.Services
{
    public class OrderUserService : IOrderUserService
    {
        private readonly IUnitOfWork _uow;
        public OrderUserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OrderUser> Add(long orderID, long userID)
        {
            var orderUser = await _uow.OrderUserRepository.Add(
                new OrderUser(orderID, userID)
            );

            await _uow.SaveChange();

            return orderUser;
        }
    }
}