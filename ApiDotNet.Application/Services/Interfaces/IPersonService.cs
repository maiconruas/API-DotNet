using ApiDotNet.Application.DTOs;

namespace ApiDotNet.Application.Services.Interfaces
{
	internal interface IPersonService
	{
		Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
	}
}
