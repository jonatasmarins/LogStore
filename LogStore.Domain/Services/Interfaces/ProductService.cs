using System.Collections.Generic;
using System.Threading.Tasks;
using LogStore.Domain.Models;
using LogStore.Domain.Repositories.Uow;
using LogStore.Domain.Extensions;

namespace LogStore.Domain.Services.Interfaces
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<decimal> CalculateOrderTotalValue(IList<OrderItemModel> orderItems)
        {
            decimal total = 0;

            foreach (var item in orderItems)
            {
                total += await CalculateOrderItemTotalValue(item);
            }

            return total;
        }

        public async Task<decimal> CalculateOrderItemTotalValue(OrderItemModel orderItem)
        {
            decimal total = 0;

            foreach (var productID in orderItem.Products)
            {
                var product = await _uow.ProductRepository.GetProductById(productID);

                total += (orderItem.Products.Count > 1
                    ? (product.Value / 2)
                    : product.Value).TruncateDecimal(2);
            }

            return total;
        }
    }
}