using ApiDotNet.Application.DTOs;

namespace ApiDotNet.Application.Services.Interfaces
{
	public interface IPurchaseService
	{
		Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
		Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id);
		Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO);
		Task<ResultService> RemoveAsync(int id);
		Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
	}
}
