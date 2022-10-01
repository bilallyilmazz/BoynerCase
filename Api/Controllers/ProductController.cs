
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.CQRS.MediatorPattern.Commands;
using Services.CQRS.MediatorPattern.Queries;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(CreateProductCommand command)
        {
            if (ModelState.IsValid)
            {
                return Ok(await _mediator.Send(command));

            }
            else
            {
                return BadRequest();
            }



        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] GetProductsQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
