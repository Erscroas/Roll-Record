using RollAndRecord.Core.Interfaces.Repositories;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace RollAndRecord.Core.Services.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        SQLiteAsyncConnection _database;
        public BaseRepository(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<List<T>> All() => await _database.GetAllWithChildrenAsync<T>(recursive: true);
        public async Task<T> Get(int id) => await _database.GetWithChildrenAsync<T>(id, recursive: true);
        public async Task Save(T entity) => await _database.InsertOrReplaceWithChildrenAsync(entity);
        public async Task Delete(T entity) => await _database.DeleteAsync(entity, recursive: true);
    }
}
