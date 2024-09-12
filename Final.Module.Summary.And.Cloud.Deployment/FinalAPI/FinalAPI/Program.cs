using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddDbContext<ContextDAL>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("ContextDAL") ?? throw new InvalidOperationException("Connection string 'ContextDAL' not found.")));

        // builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();  
        builder.Services.AddScoped<ProductsRepository>();
        builder.Services.AddScoped<CategoryRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
