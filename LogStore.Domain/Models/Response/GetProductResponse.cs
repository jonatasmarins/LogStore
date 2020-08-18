namespace LogStore.Domain.Models.Response
{
    public class GetProductResponse
    {
        public GetProductResponse() { }

        public GetProductResponse(long productID, string name, string description, decimal value)
        {
            ProductID = productID;
            Name = name;
            Description = description;
            Value = value;
        }

        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}