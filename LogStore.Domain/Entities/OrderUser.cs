namespace LogStore.Domain.Entities
{
    public class OrderUser
    {
        public OrderUser()
        {
            
        }
        
        public long OrderUserID { get; set; }
        public long OrderID { get; set; }
        public Order Order { get; set; }

        public long UserID { get; set; }
        public User User { get; set; }
    }
}