using ApisModuleLec3.Models;

namespace ApisModuleLec3.Auth
{
	public interface IJwtTokenService
	{
		Task<string> CreateToken(AppUser user);
	}
}
