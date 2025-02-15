using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private SQLiteAsyncConnection _database;
        public CustomerRepository(SQLiteAsyncConnection database) : base(database)
        {
            _database = database;
        }
    }
}
