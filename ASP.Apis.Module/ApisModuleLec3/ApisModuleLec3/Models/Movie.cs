using ApisModuleLec3.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApisModuleLec3.Models
{
	public class Movie: IEntity
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

		public string Title { get; set; } = default!;
		public string Description { get; set; } = default!;
    }
}

//var m = new Movie();
// m.title = "The Matrix";
// m.description = "A movie about a matrix";