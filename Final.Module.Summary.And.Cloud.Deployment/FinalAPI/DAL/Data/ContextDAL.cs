using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace DAL.Data;

public class ContextDAL(DbContextOptions<ContextDAL> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>()
            .HasData([
                new Category(){
                    Id = 1,
                    Name = "Toys"
                },
                 new Category(){
                    Id = 2,
                    Name = "Electronics"
                },
                 new Category(){
                    Id = 3,
                    Name = "Games"
                }
                ]);

        modelBuilder.Entity<Product>()
            .HasData([
                new Product(){
                    Id = 1,
                    Name = "Macbook Pro",
                    Description = "A Computer",
                    CategoryId = 2,
                    ImageUrl = "",
                    Price = 999.9M
                },
                 new Product(){
                    Id = 2,
                    Name = "Toy car",
                    Description = "A Wooden Toy car",
                    CategoryId = 1,
                    ImageUrl = "",
                    Price = 10.0M
                }
                ]);
    }
}
