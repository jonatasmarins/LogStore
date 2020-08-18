using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IOrderItemTypeRepository
    {
        Task<bool> IsQuantityProductValid(long idOrderItemTypeID, int quantity);
    }
}