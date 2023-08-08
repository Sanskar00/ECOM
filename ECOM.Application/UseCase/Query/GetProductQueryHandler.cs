using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ECOM.Domain.Models;
using ECOM.Persistence.Repositories;

namespace ECOM.Application.UseCase.Query
{
	public class GetProductQueryHandler:IRequestHandler<GetProductQuery,List<Product>>
	{
		private readonly IECOMProductRepository _repository;
        public GetProductQueryHandler(IECOMProductRepository repository)
        {
            _repository= repository;
        }

		public async Task<List<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetProducts();
        }
    }
}
