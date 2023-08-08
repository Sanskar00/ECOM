using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ECOM.Domain.Models;
namespace ECOM.Application.UseCase.Query
{
	public class GetProductQuery:IRequest<List<Product>>
	{

	}
}
