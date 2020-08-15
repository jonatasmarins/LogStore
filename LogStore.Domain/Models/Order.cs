using System;
using System.Collections.Generic;

namespace LogStore.Domain.Models
{
    public class Order
    {
        public Order(long orderID, DateTime createDate, IList<OrderItem> items)
        {
            OrderID = orderID;
            CreateDate = createDate;
            Items = items;
        }

        public Order() { }

        public long OrderID { get; set; }
        public DateTime CreateDate { get; set; }
        public IList<OrderItem> Items { get; set; }
    }
}