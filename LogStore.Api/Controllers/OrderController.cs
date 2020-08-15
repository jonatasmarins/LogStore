using System.Linq;
using System.Threading.Tasks;
using LogStore.Api.Base;
using LogStore.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogStore.Api.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddOrderCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Ok(response.Value);
        }
    }
}