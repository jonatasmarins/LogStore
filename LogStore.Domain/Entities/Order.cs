using System;
using System.Collections.Generic;

namespace LogStore.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public Order(long orderID, decimal value, DateTime createDate, IList<OrderItem> items)
        {
            OrderID = orderID;
            Value = value;
            CreateDate = createDate;
            Items = items;
        }

        public long OrderID { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<OrderItem> Items { get; set; }

        // public OrderUser OrderUser { get; set; }
        // public long OrderUserID { get; set; }
    }
}