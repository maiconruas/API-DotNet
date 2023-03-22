using ApiDotNet.Application.DTOs;

namespace ApiDotNet.Application.Services.Interfaces
{
	public interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
	}
}
