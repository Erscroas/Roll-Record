using RollAndRecord.Core.Interfaces.Repositories;
using RollAndRecord.Core.Models;
using SQLite;

namespace RollAndRecord.Core.Services.Repositories
{
    public class ExpenseRepository : BaseRepository<Expense>, IExpenseRepository
    {
        private SQLiteAsyncConnection _database;
        public ExpenseRepository(SQLiteAsyncConnection database) : base(database)
        {
            _database = database;
        }

        public async Task<List<Expense>> GetExpensesByType(ExpenseType type) => await _database.Table<Expense>().Where(e => e.Type == type).ToListAsync();
    }
}
