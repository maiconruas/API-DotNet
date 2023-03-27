using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiDotNet.Infra.Data.repositories
{
	public class PersonRepository : IPersonRepository
	{
		private readonly ApplicationDbContext _context;
		public PersonRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Person> CreateAsync(Person person)
		{
			_context.Add(person);
			await _context.SaveChangesAsync();
			return person;
		}

		public async Task DeleteAsync(Person person)
		{
			_context.Remove(person);
			await _context.SaveChangesAsync();
		}

		public async Task<Person> GetByIdAsync(int id)
		{
			return await _context.People.FirstOrDefaultAsync(_ => _.Id == id);
		}

		public async Task<ICollection<Person>> GetPeopleAsync()
		{
			return await _context.People.ToListAsync();
		}

		public async Task UpdateAsync(Person person)
		{
			_context.Update(person);
			await _context.SaveChangesAsync();
		}

		public async Task<int> GetIdByDocumentAsync(string document)
		{
			return (await _context.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
		}
	}
}
