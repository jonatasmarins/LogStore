using System;
using LogStore.Domain.Entities;

namespace LogStore.TestUnit.Factories
{
    public static class OrderRepositoryFake
    {
        public static Order OrderValid()
        {
            Order order = new Order();

            order.OrderID = 1;
            order.CreateDate = DateTime.Now;
            order.Value = 150;
            order.Items = new[] {
                new OrderItem(1, 1, 1, "", 50, new[] {
                    new Product() { Value = 50}
                }),
                new OrderItem(1, 1, 1, "", 50, new[] {
                    new Product() { Value = 50},
                    new Product() { Value = 50}
                })
            };

            return order;
        }
    }
}