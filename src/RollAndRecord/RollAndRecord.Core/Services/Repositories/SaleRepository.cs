using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class SaleRepository : BaseRepository<Sale>, ISaleRepository
    {
        private SQLiteAsyncConnection _database;
        public SaleRepository(SQLiteAsyncConnection database) : base(database)
        {
            _database = database;
        }
    }
}
