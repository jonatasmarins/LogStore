using System.Collections.Generic;
using LogStore.Domain.Models.Response;
using LogStore.Domain.Shared;
using MediatR;

namespace LogStore.Domain.Commands
{
    public class GetOrdersCommand : IRequest<IResultResponse<List<GetOrdersResponse>>>
    {
        public long UserID { get; set; }
    }
}