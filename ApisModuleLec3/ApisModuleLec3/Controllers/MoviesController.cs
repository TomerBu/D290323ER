using ApisModuleLec3.Models;
using ApisModuleLec3.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApisModuleLec3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoviesController(IMovieRepository repo) : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var movies = await repo.GetAllMovies();
			return Ok(movies);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] string id)
		{
			var movie = await repo.GetByIdAsync(id);

			if (movie is null)
			{
				return NotFound();
			}

			return Ok(movie);
		}



		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Movie movie)
		{
			var result = await repo.AddMovieAsync(movie);

			//status 201 = Created!
			//TODO: GET BY ID => created!

			//Created => goto Get/{id}
			return CreatedAtAction(nameof(Get), new { Id = result.Id! }, result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put([FromRoute] string id, [FromBody] Movie movie)
		{
			var existingMovie = await repo.GetByIdAsync(id);

			if (existingMovie is null)
			{
				return NotFound();
			}

			movie.Id = id;
			await repo.UpdateAsync(movie);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] string id)
		{
			var existingMovie = await repo.GetByIdAsync(id);

			if (existingMovie is null)
			{
				return NotFound();
			}

			await repo.DeleteAsync(id);

			return NoContent();
		}
	}
}
