using System.Collections.Generic;
using LogStore.Domain.Commands;
using LogStore.Domain.Models.Request;

namespace LogStore.TestIntegration.DataGenerators
{
    public class AddOrderWithOutUserCommandDataGenerator
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new[]
            {
                new AddOrderWithOutUserCommand()
                {
                    City = "São Paulo",
                    Neighborhood = "Vila Madalena",
                    Number = 150,
                    Street = "R.Girassol",
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
                new AddOrderWithOutUserCommand()
                {
                    City = "Campinas",
                    Neighborhood = "Abolição",
                    Number = 150,
                    Street = "Ponte preta",
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
                new AddOrderWithOutUserCommand()
                {
                    City = "Indaiatuba",
                    Neighborhood = "Vila Suiça",
                    Number = 150,
                    Street = "R.Toronto",
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