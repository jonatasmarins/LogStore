using System.Collections.Generic;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Commands
{
    public class AddOrderWithOutUserCommand: IRequest<IResultResponse<AddOrderWithOutUserResponse>>
    {
        public AddOrderWithOutUserCommand()
        {
            OrderItems = new List<OrderItemModel>();
        }

        public IList<OrderItemModel> OrderItems { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
    }
}