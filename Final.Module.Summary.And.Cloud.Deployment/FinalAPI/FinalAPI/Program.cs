using DAL.Data;
using DAL.Models;
using FinalAPI.Services;
using Microsoft.AspNetCore.Identity;
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

        //add identity services to the di: (enables us to inject UserManager, RoleManager)
        builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => {
            options.User.RequireUniqueEmail = true;
            options.Password.RequiredLength = 8;
        }).AddEntityFrameworkStores<ContextDAL>();

        // builder.Services.AddScoped<IRepository<Product>, ProductsRepository>();  
        builder.Services.AddScoped<ProductsRepository>();
        builder.Services.AddScoped<CategoryRepository>();


        //add our Service to the di container
        builder.Services.AddScoped<JwtService>();

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


        //who is the user?
        app.UseAuthentication();

        //does the user have permission?
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
