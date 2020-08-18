using System.Collections.Generic;

namespace LogStore.TestUnit.DataGenerator
{
    public static class AddressRequestModelGenerate
    {
        public static IEnumerable<object[]> GetData()
        {
            yield return new[]
            {
                new AddressRequestModelFake()
                {
                    City = "",
                    Neighborhood = "São Luiz",
                    Number = 12,
                    Street = "Rua 1"
                }
            };

            yield return new[]
            {
                new AddressRequestModelFake()
                {
                    City = "São Paulo",
                    Neighborhood = "",
                    Number = 12,
                    Street = "Rua 1"
                }
            };

            yield return new[]
            {
                new AddressRequestModelFake()
                {
                    City = "São Paulo",
                    Neighborhood = "São Luiz",
                    Number = 0,
                    Street = "Rua 1"
                }
            };

            yield return new[]
            {
                new AddressRequestModelFake()
                {
                    City = "São Paulo",
                    Neighborhood = "São Luiz",
                    Number = 12,
                    Street = ""
                }
            };
        }
    }

    public class AddressRequestModelFake
    {
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
    }
}