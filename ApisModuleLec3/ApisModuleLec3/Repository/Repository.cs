using ApisModuleLec3.Models;
using ApisModuleLec3.Service;
using Humanizer;
using MongoDB.Driver;

namespace ApisModuleLec3.Repository
{
	public abstract class Repository<T>(IMongoService mongo) : IRepository<T> where T: IEntity
	{
		protected readonly IMongoCollection<T> _collection =
			mongo.GetCollection<T>(typeof(T).Name.Pluralize());

		public virtual async Task<T> AddAsync(T item)
		{
			await _collection.InsertOneAsync(item);
			return item;
		}

		public virtual async Task DeleteAsync(string id)
		{
			await _collection.DeleteOneAsync(item => item.Id == id);
		}

		public virtual async Task<IEnumerable<T>> GetAllAsync()
		{
			var cursor = await _collection.FindAsync(item => true);
			return await cursor.ToListAsync();
		}

		public virtual async Task<T?> GetByIdAsync(string id)
		{
			return await _collection.Find(item => item.Id == id).FirstOrDefaultAsync();
		}

		public virtual async Task UpdateAsync(T item)
		{
			await _collection.ReplaceOneAsync(i => i.Id == item.Id, item);
		}
	}
}