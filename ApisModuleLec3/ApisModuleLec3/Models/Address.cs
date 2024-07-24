using System.ComponentModel.DataAnnotations;


//DTO=>Model
//Repository<T>
//Controller
//http tests
namespace ApisModuleLec3.Models
{
	public class Address
	{
		//[BsonId]
		//public ObjectId id { get; set; } = new ObjectId();
        public string? State { get; set; } = string.Empty;

		[Required(ErrorMessage = "Country is required")]
		public required string Country { get; set; }

		[Required(ErrorMessage = "City is required")]
		public required string City { get; set; }

		[Required(ErrorMessage = "Street is required")]
		public required string Street { get; set; }

		[Required(ErrorMessage = "House number is required")]
		[Range(1, int.MaxValue, ErrorMessage = "House number must be positive")]
		public required int HouseNumber { get; set; }
		public int? Zip { get; set; } = 0;
	}
}
