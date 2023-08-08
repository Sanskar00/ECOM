using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOM.Domain.Models;
using ECOM.Persistence.Repositories;
using MediatR;

namespace ECOM.Application.UseCase.Command
{
	public class AddProductCommandHandler:IRequestHandler<AddProductCommand,Product>
	{
        private readonly IECOMProductRepository _repository;
        public AddProductCommandHandler(IECOMProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddProduct(request.Name, request.Description, request.Price);

        }
    }
}
