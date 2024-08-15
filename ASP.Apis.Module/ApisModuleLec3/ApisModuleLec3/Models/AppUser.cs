using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApisModuleLec3.Models
{
	public class AppUser() : MongoUser<ObjectId>() //UserName, Email, PasswordHash, Id, Roles, Claims, Logins, Tokens
	{
		// Add properties as needed
		[BsonRequired]
		public required Name Name { get; set; }

		[BsonRequired]
		public required Image Image { get; set; }

		[BsonRequired]
		public required Address Address { get; set; }

		[BsonRequired]
		public bool IsBusiness { get; set; }

		public bool IsAdmin { get; set; } = false;

		[BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
