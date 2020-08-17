using System;
using System.Collections.Generic;
using LogStore.Domain.Entities;
using LogStore.Domain.Models.Request;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Commands
{
    public class AddOrderCommand : IRequest<IResultResponse>
    {
        public AddOrderCommand()
        {
            OrderItems = new List<OrderItemModel>();
        }

        public long UserID { get; set; }
        public IList<OrderItemModel> OrderItems { get; set; }
    }
}