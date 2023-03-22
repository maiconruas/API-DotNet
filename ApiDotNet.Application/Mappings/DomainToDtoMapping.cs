using ApiDotNet.Application.DTOs;
using ApiDotNet.Domain.Entities;
using AutoMapper;

namespace ApiDotNet.Application.Mappings
{
	public class DomainToDtoMapping : Profile
	{
		public DomainToDtoMapping() 
		{
			CreateMap<Person, PersonDTO>();
		}
	}
}
