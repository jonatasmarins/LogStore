using System.Collections.Generic;
using LogStore.Domain.Models.Request;

namespace LogStore.TestUnit.DataGenerator
{
    public static class OrderItemModelGenerator
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new[]
            {
                new OrderItemModelData()
                {
                    OrderItemModel = new OrderItemModel()
                    {
                        Description = "",
                        OrderItemTypeID = 1,
                        Products = { 1 }
                    },
                    TotalValue = 50
                }
            };

            yield return new[] {

                new OrderItemModelData()
                {
                    OrderItemModel = new OrderItemModel()
                    {
                        Description = "",
                        OrderItemTypeID = 1,
                        Products = { 2, 3 }
                    },
                    TotalValue = 51.24M
                }
            };

            yield return new[] {
                new OrderItemModelData()
                {
                    OrderItemModel = new OrderItemModel()
                    {
                        Description = "",
                        OrderItemTypeID = 1,
                        Products = { 5, 6 }
                    },
                    TotalValue = 50
                }
            };

            yield return new[] {
                new OrderItemModelData()
                {
                    OrderItemModel = new OrderItemModel()
                    {
                        Description = "",
                        OrderItemTypeID = 1,
                        Products = { 5, 7 }
                    },
                    TotalValue = 57.49M
                }
            };
        }
    }

    public class OrderItemModelData
    {
        public OrderItemModel OrderItemModel { get; set; }
        public decimal TotalValue { get; set; }
    }
}