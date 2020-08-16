using System.Threading.Tasks;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Request;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<Order> AddOrderItem(Order order, OrderItemModel item, decimal valueTotalItem);
    }
}