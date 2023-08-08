using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ECOM.Application.UseCase.Query;
using ECOM.Domain;
using ECOM.Domain.Models;
using MediatR;

namespace ECOM.Application.UseCase.Command
{
	public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommand,Product>
	{
		private readonly IMediator _mediator;
		private readonly IDataContext _context;
		public DataContext dataContext = new();

        public UpdateProductCommandHandler(IMediator mediator,IDataContext context)
        {
            _mediator=mediator;
			_context=context;
        }
        public async Task<Product> Handle(UpdateProductCommand request,CancellationToken cancellationToken)
		{
			var result = await _mediator.Send(new GetProductByIdQuery(request.Id));
			if (result != null)
			{
				result.Name = request.Name != "string" ? request.Name : result.Name;
				result.Description = request.Description != "string" ? request.Description : result.Description;
				result.Price = request.Price;
				await (_context as DataContext).SaveChangesAsync();
			}
			
			
			return result;
		}
	}
}
