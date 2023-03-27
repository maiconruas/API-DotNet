using ApiDotNet.Application.DTOs;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Application.Services;
using ApiDotNet.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseController : ControllerBase
	{
		private readonly IPurchaseService _purchaseService;

		public PurchaseController(IPurchaseService purchaseService)
		{
			_purchaseService = purchaseService;
		}


		[HttpPost]
		public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
		{
			try
			{
				var result = await _purchaseService.CreateAsync(purchaseDTO);
				if (result.IsSuccess)
					return Ok(result);

				return BadRequest(result);
			}
			catch (DomainValidationException ex)
			{
				var result = ResultService.Fail(ex.Message);
				return BadRequest(result);
			}
		}


		[HttpGet]
		public async Task<ActionResult> GetAsync()
		{
			var result = await _purchaseService.GetAsync();
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}


		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult> GetIdAsync(int id)
		{
			var result = await _purchaseService.GetByIdAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPut]
		public async Task<ActionResult> UpdateAsync([FromBody] PurchaseDTO purchaseDTO)
		{
			try
			{
				var result = await _purchaseService.UpdateAsync(purchaseDTO);
				if (result.IsSuccess)
					return Ok(result);

				return BadRequest(result);
			}
			catch (DomainValidationException ex)
			{
				var result = ResultService.Fail(ex.Message);
				return BadRequest(result);
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<ActionResult> RemoveAsync(int id)
		{
			var result = await _purchaseService.RemoveAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}
