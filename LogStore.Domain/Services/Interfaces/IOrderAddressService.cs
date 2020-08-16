using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IOrderAddressService
    {
        Task<OrderAddress> Add(long orderID, long addressID);
    }
}