namespace LogStore.Domain.Entities
{
    public class OrderUser
    {
        public OrderUser()
        {
            
        }

        public OrderUser(long orderID, long userID)
        {
            OrderID = orderID;
            UserID = userID;
        }
        
        public long OrderUserID { get; set; }
        public long OrderID { get; set; }
        public Order Order { get; set; }

        public long UserID { get; set; }
        public User User { get; set; }
    }
}