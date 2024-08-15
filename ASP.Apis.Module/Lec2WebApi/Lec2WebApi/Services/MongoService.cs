using MongoDB.Bson;
using MongoDB.Driver;

namespace Lec2WebApi.Services
{
    public class MongoService
    {
        //props:
        public IMongoDatabase database;

        //constructor:
        public MongoService(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("MongoDBConnectionString");
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(config["DatabaseName"]);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }
    }
}
// (MongoService s){
// s.database.GetCollection<WeatherForecast>("WeatherForecast");
// s.GetCollection<WeatherForecast>("WeatherForecast");
//}
