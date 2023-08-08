using ECOM.Application.UseCase.Command;
using ECOM.Application.UseCase.Query;
using ECOM.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECOM.API.Controllers
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
        // GET: api/<ProductController>
        [HttpGet]
		public async Task<List<Product>> Get()
		{
			return await _mediator.Send(new GetProductQuery());
		}

		// GET api/<ProductController>/5
		[HttpGet("{id}")]
		public async Task<Product> Get(string id)
		{
			return await _mediator.Send(new GetProductByIdQuery(id)) ;
		}

		// POST api/<ProductController>
		[HttpPost]
		public async Task<Product> Post([FromBody] Product value)
		{
			var model = new AddProductCommand(value.Name,value.Description,value.Price);
			return await _mediator.Send(model);
		}

		// PUT api/<ProductController>/5
		[HttpPut("{id}")]
		public async Task<Product> Put(string id, [FromBody] Product value)
		{
			var model = new UpdateProductCommand(id, value.Name, value.Description, value.Price);
			return await _mediator.Send(model);
		}

		// DELETE api/<ProductController>/5
		[HttpDelete("{id}")]
		public async Task<Product> Delete(string id)
		{
			var model=new DeleteProductCommand(id);
			return await _mediator.Send(model);
		}
	}
}
