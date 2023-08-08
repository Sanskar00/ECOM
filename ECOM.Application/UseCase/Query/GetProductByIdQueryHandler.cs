using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOM.Domain.Models;
using ECOM.Persistence.Repositories;
using MediatR;

namespace ECOM.Application.UseCase.Query
{
	public class GetProductByIdQueryHandler:IRequestHandler<GetProductByIdQuery,Product>
	{
		private readonly IMediator _mediator;

        public GetProductByIdQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Product> Handle(GetProductByIdQuery request,CancellationToken cancellationToken)
        {
            var productList = await _mediator.Send(new GetProductQuery());
            var output=productList.FirstOrDefault(p=>p.Id==request.Id);
            return output;
        }
    
    }
}
