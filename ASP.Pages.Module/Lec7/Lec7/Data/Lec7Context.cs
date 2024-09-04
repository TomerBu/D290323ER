using Lec7.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Lec7.Data;

public class Lec7Context(DbContextOptions<Lec7Context> options)
    : IdentityDbContext<AppUser, IdentityRole, string>(options)
{
    public DbSet<Product> Product { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var hasher = new PasswordHasher<AppUser>();
        //Seed roles: //INSERT INTO ROLE VALUES(...), (...)
        builder.Entity<IdentityRole>()
            .HasData(
                new IdentityRole() { Id = "1", Name = "Admin" },
                new IdentityRole() { Id = "2", Name = "User" }
            );

        var user = new AppUser()
        {
            Id = "B87B5C23-CCB2-4DB0-925E-95224DF0A2F9",
            UserName = "TomerBu@gmail.com",
            Email = "TomerBu@gmail.com",
            Language = "C#",
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            NormalizedEmail = "TOMERBU@GMAIL.COM",
            NormalizedUserName = "TOMERBU@GMAIL.COM"
        };

        user.PasswordHash = hasher.HashPassword(user, "123456");

        builder
            .Entity<AppUser>()
            .HasData(user);

        builder
            .Entity<IdentityUserRole<string>>()
            .HasData(
            new IdentityUserRole<string>() { RoleId = "1", UserId = user.Id });
    }
}
