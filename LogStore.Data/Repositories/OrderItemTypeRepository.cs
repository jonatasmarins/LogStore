using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class OrderItemTypeRepository : IOrderItemTypeRepository
    {
        private readonly DataContext _dataContext;

        public OrderItemTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<bool> IsQuantityProductValid(long idOrderItemTypeID, int quantity)
        {
            var result = _dataContext.OrderItemTypes
                .Where(x => x.OrderItemTypeID == idOrderItemTypeID).FirstOrDefault();

            return Task.FromResult(result.QuantityProduct == quantity);
        }
    }
}