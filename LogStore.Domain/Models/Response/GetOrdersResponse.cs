using System;
using System.Collections.Generic;
using LogStore.Domain.Entities;

namespace LogStore.Domain.Models.Response
{
    public class GetOrdersResponse
    {
        public GetOrdersResponse()
        {
            User = new GetUserResponse();
            Items = new List<GetOrderItemResponse>();
        }
        public long OrderID { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
        public GetUserResponse User { get; set; }
        public List<GetOrderItemResponse> Items { get; set; }
    }
}