using System.Collections.Generic;

namespace LogStore.Domain.Entities
{
    public class OrderItem
    {

        public OrderItem() { }

        public OrderItem(
            long orderItemID,
            long orderID,
            long orderItemTypeID,
            string description,
            decimal value,
            IList<OrderSubItem> products
        )
        {
            OrderItemID = orderItemID;
            Description = description;
            OrderItemTypeID = orderItemTypeID;
            Products = products;
            OrderID = orderID;
            Value = value;
        }

        public OrderItem(
            long orderID,
            long orderItemTypeID, 
            string description, 
            decimal value,
            IList<OrderSubItem> products
        )
        {
            Description = description;
            OrderItemTypeID = orderItemTypeID;
            Products = products;
            OrderID = orderID;
            Value = value;
        }

        public long OrderItemID { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public OrderItemType OrderItemType { get; set; }
        public long OrderItemTypeID { get; set; }

        public IList<OrderSubItem> Products { get; set; }

        public Order Order { get; set; }
        public long OrderID { get; set; }
    }
}