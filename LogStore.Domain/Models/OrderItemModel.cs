using System.Collections.Generic;

namespace LogStore.Domain.Models
{
    public class OrderItemModel
    {
        public OrderItemModel()
        {
            Products = new List<ProductModel>();
        }

        public long OrderItemTypeID { get; set; }
        public string Description { get; set; }
        public IList<ProductModel> Products { get; set; }
    }
}