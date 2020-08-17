using System.Collections.Generic;

namespace LogStore.Domain.Models.Response
{
    public class GetOrderItemResponse
    {
        public GetOrderItemResponse()
        {
            OrderItemType = new GetOrderItemTypeResponse();
            Product = new List<GetProductResponse>();
        }

        public long OrderItemID { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public GetOrderItemTypeResponse OrderItemType { get; set; }
        public List<GetProductResponse> Product { get; set; }
    }
}