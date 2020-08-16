namespace LogStore.Domain.Entities
{
    public class Address
    {
        public Address() { }

        public Address(string street, string city, int number, string neighborhood)
        {
            Street = street;
            City = city;
            Number = number;
            Neighborhood = neighborhood;
        }

        public long AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
    }
}