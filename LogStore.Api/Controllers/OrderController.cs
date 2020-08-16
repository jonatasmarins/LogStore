using System.Linq;
using System.Threading.Tasks;
using LogStore.Api.Base;
using LogStore.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogStore.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/Order")]
        public async Task<IActionResult> Add([FromBody] AddOrderCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Response(response);
        }

        [HttpPost("/Order/WihtOutUser")]
        public async Task<IActionResult> Add([FromBody] AddOrderWithOutUserCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Response(response);
        }
    }
}