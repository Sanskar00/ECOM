using ECOM.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ECOM.Domain
{
	public interface IDataContext
	{
		DbSet<Product> Products { get; set; }
		//Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
	}
}