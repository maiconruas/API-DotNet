using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace ApiDotNet.Infra.Data.repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User> GetUserBuEmailAndPasswordAsync(string email, string password)
		{
			return await _context.Users.FirstOrDefaultAsync(_ => _.Email == email && _.Password == password);
		}
	}
}
