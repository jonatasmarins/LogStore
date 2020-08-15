using LogStore.Domain.Entities;

namespace LogStore.TestUnit.Factories
{
    public static class ProductRepositoryFake
    {
        public static Product GetById() {
            return new Product() { ProductID = 1, Name = "Name Fake", Description = "Description Fake", Value = 50  };
        }
    }
}