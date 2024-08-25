using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lec5.Data;
namespace Lec5
{
    public class Program
    {


        // short if statement:
        static void sayHello2(string name)
        {
            Console.WriteLine(name == null ? "Guest" : name);
        }

        //null coallescing operator
        static void sayHello(string name)
        {
            Console.WriteLine(name ?? "Guest");
        }

        //Null-conditional operators 
        static void sayHello3(string? name)
        {
            //if (name is not null) => name to lower case else "guest"
            var greet = name?.ToLower() ?? "guest";
        }

        public static void Main(string[] args)
        {


            var builder = WebApplication.CreateBuilder(args);

            //Break Early -> better code, devs will know what happend
            //TDD - Test Driven Development 
            var con = builder.Configuration.GetConnectionString("Lec5Context")
                ??
            throw new Exception("Can't find the connection string in appsettings.json");


            builder.Services.AddDbContext<Lec5Context>(options =>
                options.UseSqlServer(con));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
