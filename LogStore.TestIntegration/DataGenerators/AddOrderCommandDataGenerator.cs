using System.Collections.Generic;
using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;

namespace LogStore.TestIntegration.DataGenerators
{
    public class AddOrderCommandDataGenerator
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new[]
            {
                new AddOrderCommand()
                {
                    UserID = 1,
                    OrderItems = new[] {
                        new OrderItemModel() {
                            OrderItemTypeID = 2,
                            Description = "Remover Cebola",
                            Products = {1, 7}
                        },
                        new OrderItemModel() {
                            OrderItemTypeID = 2,
                            Description = "Remover Cebola",
                            Products = {2, 4}
                        }
                    }
                }
            };

            yield return new[]
            {
                new AddOrderCommand()
                {
                    UserID = 2,
                    OrderItems = new[] {
                        new OrderItemModel() {
                            OrderItemTypeID = 1,
                            Description = "",
                            Products = {2}
                        }
                    }
                }
            };

            yield return new[]
            {
                new AddOrderCommand()
                {
                    UserID = 1,
                    OrderItems = new[] {
                        new OrderItemModel() {
                            OrderItemTypeID = 4,
                            Description = "Remover Cebola",
                            Products = {5, 6}
                        }
                    }
                }
            };
        }

    }
}