using ApisModuleLec3.Models;

namespace ApisModuleLec3.Repository
{
	public interface IMovieRepository
	{
		Task<IEnumerable<Movie>> GetAllMovies();
		
		Task<Movie> AddMovieAsync(Movie movie);

		Task<Movie?> GetByIdAsync(string id);

		Task UpdateAsync(Movie movie);

		Task  DeleteAsync(string id);
	}
}
//Irepo
//Repo
//Controller
//Swagger