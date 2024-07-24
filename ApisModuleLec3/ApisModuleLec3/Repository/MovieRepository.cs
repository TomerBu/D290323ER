using ApisModuleLec3.Models;
using ApisModuleLec3.Service;
using MongoDB.Driver;

namespace ApisModuleLec3.Repository
{
	public class MovieRepository(IMongoService mongo) :Repository<Movie>(mongo)
	{
		
	}
}

//API: Controller=>Repository;
