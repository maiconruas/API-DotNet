using ApiDotNet.Application.DTOs;
using ApiDotNet.Domain.FiltersDb;

namespace ApiDotNet.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> GetAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
		Task<ResultService> UpdateAsync(PersonDTO personDTO);
		Task<ResultService> RemoveAsync(int id);
		Task<ResultService<PagedResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb);
	}
}
