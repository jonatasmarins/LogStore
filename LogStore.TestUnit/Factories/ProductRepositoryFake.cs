using LogStore.Domain.Entities;

namespace LogStore.TestUnit.Factories
{
    public static class ProductRepositoryFake
    {
        public static Product GetById()
        {
            return new Product()
            {
                ProductID = 1,
                Name = "Name Fake",
                Description = "Description Fake",
                Value = 50
            };
        }

        public static Product GetProduct(long productID)
        {
            Product product = new Product();

            switch (productID)
            {
                case 1: {
                    product.ProductID = 1;
                    product.Value = 50;
                } break;

                case 2: {
                    product.ProductID = 2;
                    product.Value = 59.99M;
                } break;

                case 3: {
                    product.ProductID = 3;
                    product.Value = 42.50M;
                } break;

                case 4: {
                    product.ProductID = 4;
                    product.Value = 42.50M;
                } break;

                case 5: {
                    product.ProductID = 5;
                    product.Value = 55;
                } break;

                case 6: {
                    product.ProductID = 6;
                    product.Value = 45;
                } break;

                case 7: {
                    product.ProductID = 7;
                    product.Value = 59.99M;
                } break;
            }

            return product;
        }
    }
}