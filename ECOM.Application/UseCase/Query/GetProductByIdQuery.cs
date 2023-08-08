using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOM.Domain.Models;
using MediatR;

namespace ECOM.Application.UseCase.Query
{
	public record GetProductByIdQuery(string Id):IRequest<Product>;
}
