using System;
using System.Threading.Tasks;

namespace LogStore.Domain.Repositories
{
    public interface IOrderItemTypeRepository
    {
        Task<bool> IsQuantityProductValid(long idOrderItemTypeID, int quantity);
    }
}