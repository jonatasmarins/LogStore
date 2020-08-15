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
            IList<Product> products
        )
        {
            OrderItemID = orderItemID;
            Description = description;
            OrderItemTypeID = orderItemTypeID;
            Products = products;
            OrderID = orderID;
        }

        public OrderItem(
            long orderID,
            long orderItemTypeID, 
            string description, 
            decimal value,
            IList<Product> products
        )
        {
            Description = description;
            OrderItemTypeID = orderItemTypeID;
            Products = products;
            OrderID = orderID;
        }

        public long OrderItemID { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public OrderItemType OrderItemType { get; set; }
        public long OrderItemTypeID { get; set; }

        public IList<Product> Products { get; set; }

        public Order Order { get; set; }
        public long OrderID { get; set; }
    }
}