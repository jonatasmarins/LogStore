using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LogStore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(long userID)
        {
            return await _context.Users.Include(x => x.Address).Where(x => x.UserID == userID).FirstOrDefaultAsync();
        }
    }
}