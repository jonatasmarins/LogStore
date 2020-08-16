using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderAddressRepository
    {
        Task<OrderAddress> Add(OrderAddress entity);
    }
}