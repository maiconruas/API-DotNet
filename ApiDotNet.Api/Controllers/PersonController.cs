using ApiDotNet.Application.DTOs;
using ApiDotNet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonService _personService;

		public PersonController(IPersonService personService)
		{
			_personService = personService;
		}

		[HttpGet]

		public async Task<IActionResult> GetAsync()
		{
			var result = await _personService.GetAsync();
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetIdAsync(int id)
		{
			var result = await _personService.GetByIdAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] PersonDTO personDTO)
		{
			var result = await _personService.CreateAsync(personDTO);
			if(result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateAsync([FromBody] PersonDTO personDTO)
		{
			var result = await _personService.UpdateAsync(personDTO);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _personService.RemoveAsync(id);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}
