using ApiDotNet.Application.DTOs;

namespace ApiDotNet.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
		Task<ResultService<ICollection<PersonDTO>>> GetAsync();
		Task<ResultService<PersonDTO>> GetByIdAsync(int id);
		Task<ResultService> UpdateAsync(PersonDTO personDTO);
		Task<ResultService> RemoveAsync(int id);
	}
}
