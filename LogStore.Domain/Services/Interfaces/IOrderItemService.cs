using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;
using LogStore.Domain.Models;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<Order> AddOrderItem(Order order, OrderItemModel item, decimal valueTotalItem);
    }
}