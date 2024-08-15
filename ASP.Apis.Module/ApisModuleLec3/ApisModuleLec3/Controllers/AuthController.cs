using ApisModuleLec3.Auth;
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
			SignInManager<AppUser> signInManager, 
			IJwtTokenService jwtTokenService
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

		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] LoginDto dto)
		{
			//1) fetch the user by email
			var user = await userManager.FindByEmailAsync(dto.Email);
			if(user is null)
			{
				return Unauthorized();
			}

			//2) check the password
			//same as before but without sending a cookie
			var isLoggedIn = await userManager.CheckPasswordAsync(user, dto.Password);

			//3) if the password is correct, generate the token
			if (isLoggedIn)
			{
				var token = await jwtTokenService.CreateToken(user);
				return Ok(token);
			}

			return Unauthorized();
		}
	}
}


//TODO : Implement JWT Token
//take the username + id
//take the secret key
//generate the token
//send the token to the client
//id=9;username=ah;asdasdklasjdlaskjdlkasjdklsb

//the client will save the token