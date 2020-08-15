using System.Collections.Generic;

namespace LogStore.Domain.Models
{
    public class OrderItem
    {
        public OrderItem(long orderItemID, string name, string description, IList<OrderSubItem> subItems)
        {
            OrderItemID = orderItemID;
            Name = name;
            Description = description;
            SubItems = subItems;
        }

        public OrderItem() { }

        public long OrderItemID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<OrderSubItem> SubItems { get; set; }
        public long OrderSubItemID { get; set; }
        public Order Order { get; set; }
    }
}