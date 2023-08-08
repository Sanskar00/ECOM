using ECOM.Domain.Models;

namespace ECOM.Persistence.Repositories
{
	public interface IECOMProductRepository
	{
		Task<List<Product>> GetProducts();
		Task<Product> AddProduct(string name, string description, int price);
	}
}