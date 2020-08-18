namespace LogStore.Domain.Models.Response
{
    public class GetAddressResponse
    {
        public long AddressID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
    }
}