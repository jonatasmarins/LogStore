using System.Linq;
using System.Threading.Tasks;
using LogStore.Api.Base;
using LogStore.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LogStore.Api.Controllers
{
    [Route("/v1/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("/User")]
        public async Task<IActionResult> Get([FromQuery]GetOrdersCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Response(response);
        }

        [HttpGet("/WithOutUser")]
        public async Task<IActionResult> GetWithOutUser([FromQuery]GetOrdersWithOutUserCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Response(response);
        }

        [HttpPost("/User")]
        public async Task<IActionResult> Add([FromBody] AddOrderCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return Response(response);
        }

        [HttpPost("/WithOutUser")]
        public async Task<IActionResult> AddWithOutUser([FromBody] AddOrderWithOutUserCommand command)
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