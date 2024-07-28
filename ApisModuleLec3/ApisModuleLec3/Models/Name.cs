using System.ComponentModel.DataAnnotations;

namespace ApisModuleLec3.Models
{
	public class Name
	{
		[Required, MinLength(2), MaxLength(256)]
		public required string First { get; set; }
		[Required, MinLength(2), MaxLength(256)]
		public required string Last { get; set; }
		[MinLength(2), MaxLength(256)]
		public string? Middle { get; set; } = "";
	}
}
