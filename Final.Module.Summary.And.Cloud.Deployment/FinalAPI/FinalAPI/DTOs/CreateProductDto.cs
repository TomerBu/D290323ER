using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace FinalAPI.DTOs;

public class CreateProductDto
{
    [Required]
    [MinLength(1), MaxLength(30)]
    public required string Name { get; set; }

    [Required]
    [MinLength(1), MaxLength(30)]
    public required string Description { get; set; }
    public decimal Price { get; set; }

    [Required]
    [MinLength(1), MaxLength(30)]
    public required string ImageUrl { get; set; }

    [Required]
    [Range(1, 100)]
    public required int CategoryId { get; set; }
}

public static class CreateProductDtoExtensions
{
    public static Product ToProduct(this CreateProductDto dto)
    {
        return new Product
        {
            CategoryId = dto.CategoryId,
            ImageUrl = dto.ImageUrl,
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
        };
    }
}