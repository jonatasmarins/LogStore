using System;
using System.Collections.Generic;
using LogStore.Domain.Entities;
using LogStore.Domain.Models;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Commands
{
    public class AddOrderCommand : IRequest<IResultResponse<Order>>
    {
        public AddOrderCommand()
        {
            OrderItems = new List<OrderItemModel>();
        }
        public IList<OrderItemModel> OrderItems { get; set; }
    }
}