using ApisModuleLec3.Models;
using ApisModuleLec3.Service;

namespace ApisModuleLec3.Repository
{
	public class CardRepository(IMongoService mongo) : Repository<Card>(mongo)
	{

	}
}
//final step add the repo as a service to the di container (program.cs)

//Repo=>controller=>http