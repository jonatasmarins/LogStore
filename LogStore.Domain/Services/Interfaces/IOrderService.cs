using System.Threading.Tasks;
using LogStore.Domain.Commands;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrder(AddOrderCommand command, decimal totalValue);
    }
}