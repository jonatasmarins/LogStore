using System.Threading.Tasks;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(long productID);
    }
}