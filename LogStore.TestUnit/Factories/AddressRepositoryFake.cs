using LogStore.Domain.Entities;

namespace LogStore.TestUnit.Factories
{
    public static class AddressRepositoryFake
    {
        public static Address GetFirstOrDefaultValid()
        {
            return new Address()
            {
                AddressID = 1,
                City = "São Paulo",
                Neighborhood = "São Luiz",
                Number = 12,
                Street = "Rua 1"
            };
        }
    }
}