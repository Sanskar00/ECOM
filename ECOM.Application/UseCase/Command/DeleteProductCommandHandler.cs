using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOM.Application.UseCase.Query;
using ECOM.Domain;
using ECOM.Domain.Models;
using MediatR;

namespace ECOM.Application.UseCase.Command
{
	public  class DeleteProductCommandHandler:IRequestHandler<DeleteProductCommand,Product>
	{
		private readonly IMediator _mediator;
		private readonly IDataContext _context;

        public DeleteProductCommandHandler(IMediator mediator,IDataContext context)
        {
            _mediator=mediator;
            _context=context;
        }

        public async Task<Product> Handle(DeleteProductCommand request,CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetProductByIdQuery(request.Id));
            if(result!=null) {
				 _context.Products.Remove(result);
				await (_context as DataContext).SaveChangesAsync();
			}

            return result;

        }
    }
}
