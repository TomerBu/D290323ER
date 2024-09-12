
using DAL.Models;

namespace FinalAPI.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string ImageUrl { get; set; }
    public required string Category { get; set; }
}

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product p)
    {
        return new ProductDto() {
            Category = p.Category.Name, 
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            ImageUrl = p.ImageUrl,
        };
    }
}

//p.ToDto()