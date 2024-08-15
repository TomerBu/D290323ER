using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Lec2WebApi.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //[BsonElement("First_Name")]
        public string Name { get; set; } = string.Empty;
    }
}
