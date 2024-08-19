namespace Lec2.Data;

using Lec2.Models;
using Microsoft.EntityFrameworkCore;
public class Lec2DbContext(DbContextOptions<Lec2DbContext> options) : DbContext(options)
{
    //ORM = Object Relational Mapper
    public DbSet<Person> People { get; set; }
    public DbSet<Dog> Dogs { get; set; }
}