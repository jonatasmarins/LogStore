namespace LogStore.Domain.Entities
{
    public class OrderItemType
    {
        public long OrderItemTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityProduct { get; set; }
    }
}