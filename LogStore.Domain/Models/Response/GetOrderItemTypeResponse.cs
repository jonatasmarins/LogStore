namespace LogStore.Domain.Models.Response
{
    public class GetOrderItemTypeResponse
    {
        public long OrderItemTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityProduct { get; set; }
    }
}