using Microsoft.EntityFrameworkCore;
using Lec5.Models;

namespace Lec5.Data;

public class Lec5Context(DbContextOptions<Lec5Context> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; } = default!;
    public DbSet<Capital> Capitals { get; set; } = default!;
    public DbSet<Song> Songs { get; set; } = default!;
    public DbSet<Album> Albums { get; set; } = default!;
    public DbSet<Movie> Movies { get; set; } = default!;
    public DbSet<Genre> Genres { get; set; } = default!;
  
}