using System.Collections.Generic;

namespace LogStore.Domain.Models
{
    public class OrderItemModel
    {
        public OrderItemModel()
        {
            Products = new List<long>();
        }

        public long OrderItemTypeID { get; set; }
        public string Description { get; set; }
        public IList<long> Products { get; set; }
    }
}