using MongoDB.Driver;

namespace ApisModuleLec3.Service
{
	public class MongoService:IMongoService
	{
		//prop:
		private readonly IMongoDatabase _database;

		//ctor:
		public MongoService(IConfiguration config)
		{
			var connectionString = config.GetConnectionString("DefaultConnection");
			var client = new MongoClient(connectionString);
			_database = client.GetDatabase(config["DatabaseName"]);
		}

		//method:
		public IMongoCollection<T> GetCollection<T>(string name)
		{
			return _database.GetCollection<T>(name);
		}
	}
}
