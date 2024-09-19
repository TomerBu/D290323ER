using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DAL.Data;

public class ContextDAL(DbContextOptions<ContextDAL> options) :
    IdentityDbContext<AppUser, IdentityRole<int>, int>(options)
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

        modelBuilder.Entity<IdentityRole<int>>()
            .HasData([
                new IdentityRole<int>(){
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            ]);

        var hasher = new PasswordHasher<AppUser>();

        modelBuilder.Entity<AppUser>()
            .HasData([
                new AppUser(){
                    Id = 1,
                    Email = "tomerbu@gmail.com",
                    NormalizedEmail = "TOMERBU@GMAIL.COM",
                    UserName = "TomerBu",
                    NormalizedUserName = "TOMERBU",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "123456")
                }
            ]);

        modelBuilder.Entity<IdentityUserRole<int>>().HasData([
            new IdentityUserRole<int>(){
                RoleId = 1,
                UserId = 1,
            }
        ]);
    }
}