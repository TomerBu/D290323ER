using Lec7Practice.DTOs;
using Lec7Practice.Models;

namespace Lec7Practice.Mappings
{
    public static class ProductExtensions
    {
        public static ProductResponseDto ToDto(this Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Price = product.Price,
                ProdcutName = product.Name,
            };
        }
    }
}
