namespace ApisModuleLec3.Models
{
	public class JwtSettings
	{
		public required string SecretKey { get; set; }
		public required string Issuer { get; set; }
		public required string Audience { get; set; }

		//Factory method
		public static JwtSettings NewInstance() =>
			new() { Audience = "", Issuer = "", SecretKey = "" };
	}
}
