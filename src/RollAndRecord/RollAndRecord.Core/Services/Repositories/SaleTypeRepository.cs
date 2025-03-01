using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class SaleTypeRepository(SQLiteAsyncConnection database) : BaseRepository<SaleType>(database), ISaleTypeRepository
    {
        private SQLiteAsyncConnection _database = database;
    }
}
