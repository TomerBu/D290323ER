using ApisModuleLec3.DTOs.User;
using ApisModuleLec3.Models;

namespace ApisModuleLec3.Mappings
{
	public static class RegisterDtoExtensions
	{
		public static AppUser ToAppUser(this RegisterDto registerDto)
		{
			return new AppUser
			{
				//we need to login with email
				UserName = registerDto.Email,
				Email = registerDto.Email,
				PhoneNumber = registerDto.Phone,
				
				//Password is ignored for now - the framrwork will add it
				
				Name = registerDto.Name,
				Image = registerDto.Image,
				Address = registerDto.Address,
				IsBusiness = registerDto.IsBusiness,
			};
		}
	}
}
