using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderUserRepository
    {
        Task<OrderUser> Add(OrderUser entity);
    }
}