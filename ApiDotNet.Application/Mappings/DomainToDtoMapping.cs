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
			CreateMap<Product, ProductDTO>();
			CreateMap<Purchase, PurchaseDetailDTO>()
			.ForMember(x => x.Product, opt => opt.Ignore())
			.ForMember(x => x.Person, opt => opt.Ignore())
			.ConstructUsing((model, context) =>
			{
				var dto = new PurchaseDetailDTO
				{
					Person = model.Person.Name,
					Id = model.Id,
					Product = model.Product.Name,
					Date = model.Date
				};
				return dto;
			});
		}
	}
}
