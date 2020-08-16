using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderItemRepository
    {
        Task<IList<OrderItem>> Add(IList<OrderItem> item);
    }
}