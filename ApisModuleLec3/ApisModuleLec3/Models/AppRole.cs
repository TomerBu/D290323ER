using AspNetCore.Identity.Mongo.Model;
using MongoDB.Bson;

namespace ApisModuleLec3.Models
{
	public class AppRole(): MongoRole<ObjectId>()
	{
		// Add properties as needed
	}
}

//models => dtos => repository => controller => program.cs