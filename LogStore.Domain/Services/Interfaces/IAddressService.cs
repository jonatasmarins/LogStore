using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Services.Interfaces
{
    public interface IAddressService
    {
        Task<Address> Add(string street, string city, int number, string neighborhood);
    }
}