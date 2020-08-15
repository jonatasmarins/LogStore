using System.Linq;
using System.Threading.Tasks;
using LogStore.Data.Context;
using LogStore.Domain.Entities;
using LogStore.Domain.Repositories;

namespace LogStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Task<Product> GetProductById(long productID)
        {
            var product = _context.Products.Where(x => x.ProductID == productID).FirstOrDefault();
            return Task.FromResult(product);
        }
    }
}