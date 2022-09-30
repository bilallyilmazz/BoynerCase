
using MediatR;
using Microsoft.AspNetCore.Http;
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
            //return Ok(await _mediator.Send(command));
            return BadRequest();
        }
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetByName(string name)
        {
            var query= new GetProductByNameQuery() { Name=name };
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("getbycategoryname")]
        public async Task<IActionResult> GetAllByCategoryId(string name)
        {
            var query = new GetAllProductByCategoryNameQuery() { CategoryName = name };
            return Ok(await _mediator.Send(query));
        }
    }
}
