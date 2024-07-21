using ApisModuleLec3.Repository;
using ApisModuleLec3.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//make our objects available to the rest of the app:
builder.Services.AddSingleton<IMongoService, MongoService>();
builder.Services.AddSingleton<IMovieRepository, MovieRepository>();

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
