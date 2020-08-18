namespace LogStore.Domain.Entities
{
    public class OrderSubItem
    {
        public OrderSubItem() { }
        public OrderSubItem(long orderItemID, long productID)
        {
            OrderItemID = orderItemID;
            ProductID = productID;
        }

        public long OrderSubItemID { get; set; }
        public OrderItem OrderItem { get; set; }
        public long OrderItemID { get; set; }

        public Product Product { get; set; }
        public long ProductID { get; set; }
    }
}