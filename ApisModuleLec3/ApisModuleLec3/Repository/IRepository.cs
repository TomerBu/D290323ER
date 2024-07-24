using ApisModuleLec3.Models;

namespace ApisModuleLec3.Repository
{
	public interface IRepository<T> where T : IEntity
	{
			Task<IEnumerable<T>> GetAllAsync();

			Task<T> AddAsync(T item);

			Task<T?> GetByIdAsync(string id);

			Task UpdateAsync(T item);

			Task DeleteAsync(string id);
	}
}
