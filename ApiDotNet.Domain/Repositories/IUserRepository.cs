using ApiDotNet.Domain.Entities;

namespace ApiDotNet.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetUserBuEmailAndPasswordAsync(string email, string password);
	}
}
