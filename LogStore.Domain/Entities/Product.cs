namespace LogStore.Domain.Entities
{
    public class Product
    {
        public Product(long productID, string name, string description, decimal value)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Value = value;
        }

        public Product(long productID) { }

        public Product() { }

        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}