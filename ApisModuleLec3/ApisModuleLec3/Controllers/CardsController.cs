using ApisModuleLec3.DTOs.Card;
using ApisModuleLec3.Mappings;
using ApisModuleLec3.Models;
using ApisModuleLec3.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApisModuleLec3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CardsController (IRepository<Card> cardsRepo): ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CardAddRequest dto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest("BadBad");
			}
			var card = dto.ToCard("TheUserId");	
			var result = await cardsRepo.AddAsync(card);

			return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var result = await cardsRepo.GetAllAsync();
			return Ok(result);
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute]string id)
		{
			var result = await cardsRepo.GetByIdAsync(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}
	}
}
