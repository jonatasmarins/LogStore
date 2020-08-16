using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IOrderUserService
    {
        Task<OrderUser> Add(long OrderID, long UserID);
    }
}