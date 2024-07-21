using MongoDB.Driver;

namespace ApisModuleLec3.Service
{
	public interface IMongoService
	{
		IMongoCollection<T> GetCollection<T>(string name);
	}
}