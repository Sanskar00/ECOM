using Microsoft.EntityFrameworkCore;
using ECOM.Domain.Models;

namespace ECOM.Domain
{
	public class DataContext : DbContext, IDataContext
	{
		public DbSet<Product> Products { get; set; }

		public Task<int> SaveChangesAsync() => base.SaveChangesAsync();
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseCosmos(
				"https://localhost:8081",
				"C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
				"E-Shop"
				);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().
				ToContainer("Products").
				HasPartitionKey(e => e.Id);
		}


	}
}
