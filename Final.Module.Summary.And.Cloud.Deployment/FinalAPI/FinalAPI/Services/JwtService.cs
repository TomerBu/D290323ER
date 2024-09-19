using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace FinalAPI.Services;

public class JwtService(IConfiguration configuration, UserManager<AppUser> userManager)
{
    public async Task<string> CreateToken(AppUser user)
    {
        var jwtSettings = configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"] ?? throw new Exception("Secret key must be set in app settings");

        //JWT is a collection of claims
        var claims = new List<Claim>()
        {
            new Claim("isVIP", "true"),
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };

        var isAdmin = await userManager.IsInRoleAsync(user, "admin");

        if (isAdmin)
        {
            claims.Add(new Claim(ClaimTypes.Role, "admin"));
        }

        //That is Encrypted using a SECRET key:
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            expires: DateTime.UtcNow.AddMinutes(30),
            claims: claims,
            signingCredentials: creds
        );

        //convert the token to a string:
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}
