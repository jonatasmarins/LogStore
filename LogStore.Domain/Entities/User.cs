using System;

namespace LogStore.Domain.Entities
{
    public class User
    {        
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateCreate { get; set; }

        public Address Address { get; set; }
        public long AddressID { get; set; }
    }
}