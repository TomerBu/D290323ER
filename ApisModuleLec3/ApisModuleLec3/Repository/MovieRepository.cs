using ApisModuleLec3.Models;
using ApisModuleLec3.Service;
using MongoDB.Driver;

namespace ApisModuleLec3.Repository
{
	public class MovieRepository(IMongoService mongo) : IMovieRepository
	{
		//private props:
		private readonly IMongoCollection<Movie> _movies = mongo.GetCollection<Movie>("movies");

		public async Task<Movie> AddMovieAsync(Movie movie)
		{
			await _movies.InsertOneAsync(movie);
			return movie;
		}


		public async Task DeleteAsync(string id)
		{
			await _movies.DeleteOneAsync(m => m.Id == id);
		}

		public async Task<IEnumerable<Movie>> GetAllMovies()
		{
			var cursor = _movies.Find(_ => true);

			//execute the find:
			var movies = await cursor.ToListAsync();

			return movies;
		}

		public async Task<Movie?> GetByIdAsync(string id)
		{
			return await _movies.Find(m => m.Id == id).FirstOrDefaultAsync();
		}

		public async Task UpdateAsync(Movie movie)
		{
			await _movies.ReplaceOneAsync(m => m.Id == movie.Id, movie);
		}
	}
}

//API: Controller=>Repository;
