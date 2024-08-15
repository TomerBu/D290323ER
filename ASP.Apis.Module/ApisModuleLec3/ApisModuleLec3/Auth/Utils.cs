using ApisModuleLec3.Models;
using AspNetCore.Identity.Mongo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using System.Text;

namespace ApisModuleLec3.Auth
{
	public class Utils
	{
		public static void setupIdentity(WebApplicationBuilder builder)
		{
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
		}
		public static void setupJwt(WebApplicationBuilder builder)
		{

			//fill our JwtSettings object with the appsettings.json file
			var jwtSettings = JwtSettings.NewInstance();
			builder.Configuration.GetSection("JwtSettings").Bind(jwtSettings);

			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
					ValidateIssuerSigningKey = true,
					ValidateLifetime = true,
					
					//bonus:
					ValidateIssuer = true,
					ValidateAudience = true,

					ValidIssuer = jwtSettings.Issuer, 
					ValidAudience = jwtSettings.Audience
				};
			});
		}
	}
}
