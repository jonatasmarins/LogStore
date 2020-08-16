using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Models;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<decimal> CalculateOrderTotalValue(IList<OrderItemModel> orderItems);
        Task<decimal> CalculateOrderItemTotalValue(OrderItemModel orderItem);
    }
}