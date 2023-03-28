using ApiDotNet.Application.DTOs;
using ApiDotNet.Application.DTOs.Validation;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.FiltersDb;
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
			if (!result.IsValid)
				return ResultService.RequestError<PersonDTO>("Problema de validacao!", result);

			var person = _mapper.Map<Person>(personDTO);
			var data = await _personRepository.CreateAsync(person);
			return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
		}

		public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
		{
			var people = await _personRepository.GetPeopleAsync();
			return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
		}

		public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
		{
			var person = await _personRepository.GetByIdAsync(id);
			if (person == null)
				return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");
			return ResultService.Ok(_mapper.Map<PersonDTO>(person));
		}

		public async Task<ResultService> RemoveAsync(int id)
		{
			var person = await _personRepository.GetByIdAsync(id);
			if (person == null)
				return ResultService.Fail("Pessoa não encontrada!");

			await _personRepository.DeleteAsync(person);
			return ResultService.Ok($"Pessoa do id:{id} deletada");
		}

		public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
		{
			if (personDTO == null)
				return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

			var validation = new PersonDTOValidation().Validate(personDTO);
			if (!validation.IsValid)
				return ResultService.RequestError<PersonDTO>("Problema de validacao!", validation);

			var person = await _personRepository.GetByIdAsync(personDTO.Id);
			if (person == null)
				return ResultService.Fail("Pessoa não encontrada!");

			person = _mapper.Map<PersonDTO, Person>(personDTO, person);
			await _personRepository.UpdateAsync(person);
			return ResultService.Ok("Pessoa editada");
		}

		public async Task<ResultService<PagedResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb)
		{
			var peoplePaged = await _personRepository.GetPagedAsync(personFilterDb);
			var result = new PagedResponseDTO<PersonDTO>(peoplePaged.TotalRegisters, _mapper.Map<List<PersonDTO>>(peoplePaged.Data));
			return ResultService.Ok(result);
		}
	}
}
