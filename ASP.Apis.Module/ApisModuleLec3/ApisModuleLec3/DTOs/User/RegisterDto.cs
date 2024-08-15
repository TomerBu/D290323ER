using ApisModuleLec3.Models;
using System.ComponentModel.DataAnnotations;

namespace ApisModuleLec3.DTOs.User
{
	public class RegisterDto
	{
		[Required]
        public required Name Name { get; set; }

		[Required]
		public required Image Image { get; set; }

		[Required]
		public required Address Address { get; set; }

        [Required, EmailAddress, MaxLength(256)]
        public required string Email { get; set; }

		[Required]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*-]).{7,20}$",
			ErrorMessage = "Password must be 7 to 20 characters and contain at least one lowercase letter, one uppercase letter, one digit, and one special characters.")]
		public required string Password { get; set; }

		[Required]
		public required bool IsBusiness { get; set; }

		[Required, Phone, MinLength(9), MaxLength(11)]
		public required string Phone { get; set; }
	}
}
