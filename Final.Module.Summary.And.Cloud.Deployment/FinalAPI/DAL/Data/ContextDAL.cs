using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DAL.Data;

public class ContextDAL(DbContextOptions<ContextDAL> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;
}
