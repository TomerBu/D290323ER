using Lec7.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Lec7.Data;

public class Lec7Context(DbContextOptions<Lec7Context> options)
    : IdentityDbContext<AppUser, IdentityRole, string>(options)
{
    public DbSet<Product> Product { get; set; } = default!;
}
 