using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class PaymentRepository(SQLiteAsyncConnection database) : BaseRepository<Payment>(database), IPaymentRepository
    {
        private SQLiteAsyncConnection _database = database;
    }
}
