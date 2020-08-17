using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(long userID);
    }
}