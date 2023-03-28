using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace ApiDotNet.Infra.Data.repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IDbContextTransaction _transaction;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task BeginTransaction()
		{
			_transaction = await _context.Database.BeginTransactionAsync();
		}

		public async Task Commit()
		{
			await _transaction.CommitAsync();
		}

		public async Task RollBack()
		{
			await _transaction.RollbackAsync();
		}

		public void Dispose()
		{
			_transaction?.Dispose();
		}

		
	}
}
