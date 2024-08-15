using Lec7Practice.DTOs;
using Lec7Practice.Models;

namespace Lec7Practice.Mappings
{
	public static class AddProductDtoExtensions
	{
		public static Product ToProduct(this AddProductDto dto)
		{
			return new Product
			{
				//Id = Guid.NewGuid().ToString(),
				Name = dto.Name,
				Price = dto.Price,
			};
		}
	}
}
