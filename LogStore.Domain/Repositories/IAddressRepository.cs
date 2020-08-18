using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IAddressRepository
    {
        Task<Address> Add(Address entity);
        Task<Address> GetById(long addressaID);
    }
}