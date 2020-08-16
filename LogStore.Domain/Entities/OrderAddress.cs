namespace LogStore.Domain.Entities
{
    public class OrderAddress
    {
        public OrderAddress()
        {
            
        }

        public OrderAddress(long orderID, long addressID)
        {
            OrderID = orderID;
            AddressID = addressID;
        }

        public long OrderAddressID { get; set; }
        
        public long OrderID { get; set; }
        public Order Order { get; set; }

        public long AddressID { get; set; }
        public Address Address { get; set; }
    }
}