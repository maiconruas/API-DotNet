using ApiDotNet.Application.DTOs;

namespace ApiDotNet.Application.Services.Interfaces
{
	public interface IPurchaseService
	{
		Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
	}
}
