using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECOM.Domain.Models;
using ECOM.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Drawing;

namespace ECOM.Persistence.Repositories
{


	public class ECOMProductRepository : IECOMProductRepository
	{
		private readonly ILogger<ECOMProductRepository> _logger;	
		private readonly IDataContext _context;
		public DataContext dataContext = new();
		public ECOMProductRepository(IDataContext context,ILogger<ECOMProductRepository> logger)
		{
			_context = context;
			_logger = logger;
		}
		public async Task<List<Product>> GetProducts()
		{
			var response = await _context.Products.ToListAsync();
			_logger.LogTrace("This is response", args: response);
			return response;
		}

		public async Task<Product> AddProduct(string name, string description, int price)
		{
			var product = new Product()
			{
				Id = Guid.NewGuid().ToString(),
				Name = name,
				Description = description,
				Price = price
			};
			_context.Products.Add(product);
			 await (_context as DataContext).SaveChangesAsync();
			return product;
			  
		}

	}
}
