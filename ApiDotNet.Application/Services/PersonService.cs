using ApiDotNet.Application.DTOs;
using ApiDotNet.Application.DTOs.Validation;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using AutoMapper;

namespace ApiDotNet.Application.Services
{
	public class PersonService : IPersonService
	{
		private readonly IPersonRepository _personRepository;
		private readonly IMapper _mapper;

		public PersonService(IPersonRepository personRepository, IMapper mapper)
		{
			_personRepository = personRepository;
			_mapper = mapper;
		}

		public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
		{
			if (personDTO == null)
				return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

			var result = new PersonDTOValidation().Validate(personDTO);
			if (result.IsValid)
				return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

			var person = _mapper.Map<Person>(personDTO);
			var data = await _personRepository.CreateAsync(person);
			return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
		}
	}
}
