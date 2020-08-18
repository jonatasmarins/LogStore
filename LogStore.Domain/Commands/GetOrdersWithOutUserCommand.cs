using System.Collections.Generic;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Commands
{
    public class GetOrdersWithOutUserCommand : IRequest<IResultResponse<List<GetOrdersWithOutUserResponse>>>
    {
        public long AddressID { get; set; }
    }
}