using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class SaleRepository(SQLiteAsyncConnection database) : BaseRepository<Sale>(database), ISaleRepository
    {
        private SQLiteAsyncConnection _database = database;
    }
}
