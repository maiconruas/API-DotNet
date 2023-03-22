using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;

namespace ApiDotNet.Infra.Data.repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public ProductRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<Product> CreateAsync(Product product)
		{
			_dbContext.SaveChanges();
			await _dbContext.SaveChangesAsync();	
			return product;
		}

		public async Task DeleteAsync(Product product)
		{
			_dbContext.Remove(product);
			await _dbContext.SaveChangesAsync();
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			return await _dbContext.Products.FirstOrDefaultAsync(_ => _.Id == id);
		}

		public async Task<ICollection<Product>> GetPeopleAsync()
		{
			return await _dbContext.Products.ToListAsync();
		}

		public async Task UpdateAsync(Product product)
		{
			_dbContext.Update(product);
			await _dbContext.SaveChangesAsync();
		}
	}
}
