using RollAndRecord.Core.Interfaces.Repositories;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace RollAndRecord.Core.Services.Repositories
{
    public class BaseRepository<T>(SQLiteAsyncConnection database) : IBaseRepository<T> where T : class, new()
    {
        public async Task<List<T>> All() => await database.GetAllWithChildrenAsync<T>(recursive: true);
        public async Task<T> Get(Guid id) => await database.GetWithChildrenAsync<T>(id, recursive: true);
        public async Task Save(T entity) => await database.InsertOrReplaceWithChildrenAsync(entity);
        public async Task Delete(T entity) => await database.DeleteAsync(entity, recursive: true);
    }
}
