using ApisModuleLec3.DTOs.User;
using ApisModuleLec3.Mappings;
using ApisModuleLec3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApisModuleLec3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController(
			UserManager<AppUser> userManager,
			SignInManager<AppUser> signInManager
		) : ControllerBase
	{
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterDto dto)
		{
			AppUser user = dto.ToAppUser();
			var result = await userManager.CreateAsync(user, dto.Password);

			if (result.Succeeded)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
