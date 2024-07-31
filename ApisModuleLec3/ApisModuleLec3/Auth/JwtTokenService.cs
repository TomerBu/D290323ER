using ApisModuleLec3.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens; //SymmetricSecurityKey, SigningCredentials, SecurityAlgorithms
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;//Encoding

namespace ApisModuleLec3.Auth
{
	public class JwtTokenService(IOptions<JwtSettings> options) : IJwtTokenService
	{
		//now we have the secret+audience+issuer
		JwtSettings jwtSettings = options.Value;

		public async Task<string> CreateToken(AppUser user)
		{
			//TODO: use database roles to determine if the user is an admin
			//this will make it async for real
			if (user is null || user.UserName is null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			List<Claim> claims = [
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.UserName)
			];

			if (user.IsAdmin)
			{
				//Custom claim
				claims.Add(new Claim("IsAdmin", "true"));
				//built-in claim
				claims.Add(new Claim(ClaimTypes.Role, "Admin"));
			}
			else
			{
				claims.Add(new Claim("IsAdmin", "false"));
				claims.Add(new Claim(ClaimTypes.Role, "User"));
			}

			//our secret key as bytes:
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

			//SingningCredentials = key + algorithm:
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: jwtSettings.Issuer,
				audience: jwtSettings.Audience,
				claims: claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: creds
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
