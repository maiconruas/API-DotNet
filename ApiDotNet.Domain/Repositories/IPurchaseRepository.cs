using ApiDotNet.Domain.Entities;

namespace ApiDotNet.Domain.Repositories
{
	internal interface IPurchaseRepository
	{
		Task<Purchase> GetByIdAsync(int id);
		Task<ICollection<Purchase>> GetPeopleAsync();
		Task<Purchase> CreateAsync(Purchase purchase);
		Task UpdateAsync(Purchase purchase);
		Task DeleteAsync(Purchase purchase);
	}
}
