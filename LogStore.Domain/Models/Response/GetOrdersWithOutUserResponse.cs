using System;
using System.Collections.Generic;

namespace LogStore.Domain.Models.Response
{
    public class GetOrdersWithOutUserResponse
    {
        public GetOrdersWithOutUserResponse()
        {
            Address = new GetAddressResponse();
            Items = new List<GetOrderItemResponse>();
        }
        public long OrderID { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
        public GetAddressResponse Address { get; set; }
        public List<GetOrderItemResponse> Items { get; set; }
    }
}