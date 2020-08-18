using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);

        Task<Order> GetById(long orderID);

        Task<IList<Order>> GetByUserId(long userID);
        Task<IList<Order>> GetByAddressId(long userID);
    }
}