using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class CustomerRepository(SQLiteAsyncConnection database) : BaseRepository<Customer>(database), ICustomerRepository
    {
        private SQLiteAsyncConnection _database = database;
    }
}
