using ApiDotNet.Domain.Entities;

namespace ApiDotNet.Domain.Repositories
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int id);
		Task<ICollection<Product>> GetPeopleAsync();
		Task<Product> CreateAsync(Product product);
		Task UpdateAsync(Product product);
		Task DeleteAsync(Product product);
	}
}
