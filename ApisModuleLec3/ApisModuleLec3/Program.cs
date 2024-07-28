using ApisModuleLec3.Models;
using ApisModuleLec3.Repository;
using ApisModuleLec3.Service;
using AspNetCore.Identity.Mongo;
using MongoDB.Bson;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddIdentityMongoDbProvider<AppUser, AppRole, ObjectId>(identity =>
{
	identity.Password.RequiredLength = 9;
	identity.Password.RequireLowercase = true;
	identity.Password.RequireUppercase = true;
	identity.Password.RequireDigit = true;
	identity.User.RequireUniqueEmail = true;
	identity.Password.RequireNonAlphanumeric = true;
	identity.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}, mongo =>
{
	mongo.ConnectionString = connectionString;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//make our objects available to the rest of the app:
builder.Services.AddSingleton<IMongoService, MongoService>();
builder.Services.AddSingleton<IRepository<Movie>, MovieRepository>();
//todo: make this a scoped service
builder.Services.AddSingleton<IRepository<Card>, CardRepository>();

//SRP (1) how to connect to mongo
//    (2) repository: CRUD Mongo operations
//    (3) contoller: routes and actions and responses

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
