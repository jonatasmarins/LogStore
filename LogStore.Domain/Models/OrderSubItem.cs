using System.Collections.Generic;

namespace LogStore.Domain.Models
{
    public class OrderSubItem
    {
        public OrderSubItem(long orderSubItemID, Product product)
        {
            OrderSubItemID = orderSubItemID;
            Product = product;
        }

        public OrderSubItem() { }

        public long OrderSubItemID { get; set; }
        public Product Product { get; set; }
        
        public long OrderItemID { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}