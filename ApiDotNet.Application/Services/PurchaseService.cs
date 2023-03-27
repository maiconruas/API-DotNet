using ApiDotNet.Application.DTOs;
using ApiDotNet.Application.DTOs.Validation;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;

namespace ApiDotNet.Application.Services
{
	public class PurchaseService : IPurchaseService
	{
		private readonly IProductRepository _productRepository;
		private readonly IPersonRepository _personRepository;
		private readonly IPurchaseRepository _purchaseRepository;

		public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository)
		{
			_productRepository = productRepository;
			_personRepository = personRepository;
			_purchaseRepository = purchaseRepository;
		}

		public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
		{
			{
				if (purchaseDTO == null)
					return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado");

				var result = new PurchaseDTOValidation().Validate(purchaseDTO);
				if (!result.IsValid)
					return ResultService.RequestError<PurchaseDTO>("Problema de validacao!", result);

				var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
				var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
				var purchase = new Purchase(productId, personId);

				var data = await _purchaseRepository.CreateAsync(purchase);
				purchaseDTO.Id = data.Id;
					return ResultService.Ok<PurchaseDTO>(purchaseDTO);
			}
		}
	}
}
