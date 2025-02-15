using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class SaleTypeRepository : BaseRepository<SaleType>, ISaleTypeRepository
    {
        private SQLiteAsyncConnection _database;
        public SaleTypeRepository(SQLiteAsyncConnection database) : base(database)
        {
            _database = database;
        }
    }
}
