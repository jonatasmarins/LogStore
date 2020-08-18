using System;

namespace LogStore.Domain.Models.Response
{
    public class GetUserResponse
    {
        public GetUserResponse()
        {
            Address = new GetAddressResponse();
        }
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreate { get; set; }
        public GetAddressResponse Address { get; set; }
    }
}