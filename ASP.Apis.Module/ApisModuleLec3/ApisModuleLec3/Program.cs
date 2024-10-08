using ApisModuleLec3.Auth;
using ApisModuleLec3.Models;
using ApisModuleLec3.Repository;
using ApisModuleLec3.Service;

var builder = WebApplication.CreateBuilder(args);

//DI: use the appsettings.json file to fill the JwtSettings object
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

// Add services to the container.
Utils.setupIdentity(builder);//password settingsw
Utils.setupJwt(builder);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//make our objects available to the rest of the app:
builder.Services.AddSingleton<IMongoService, MongoService>();
builder.Services.AddSingleton<IRepository<Movie>, MovieRepository>();
//todo: make this a scoped service
builder.Services.AddSingleton<IRepository<Card>, CardRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
