using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> Add(Order order);
    }
}