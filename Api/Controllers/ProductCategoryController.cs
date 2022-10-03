using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.CQRS.MediatorPattern.Commands.ProductCategories.Create;
using Services.CQRS.MediatorPattern.Commands.ProductCategories.Delete;
using Services.CQRS.MediatorPattern.Commands.ProductCategories.Update;
using Services.CQRS.MediatorPattern.Commands.Products.Create;
using Services.CQRS.MediatorPattern.Queries.GetCategories;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Insert(CreateCategoryCommand command)
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

        [HttpPut("update")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {

            return Ok(await _mediator.Send(command));

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {

            return Ok(await _mediator.Send(command));

        }
        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery]GetCategoriesQuery command)
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

        
    }
}
