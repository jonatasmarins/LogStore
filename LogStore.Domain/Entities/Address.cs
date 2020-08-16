namespace LogStore.Domain.Entities
{
    public class Address
    {
        public long AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
    }
}