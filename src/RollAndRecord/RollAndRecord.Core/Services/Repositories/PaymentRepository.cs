using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private SQLiteAsyncConnection _database;
        public PaymentRepository(SQLiteAsyncConnection database) : base(database)
        {
            _database = database;
        }
    }
}
