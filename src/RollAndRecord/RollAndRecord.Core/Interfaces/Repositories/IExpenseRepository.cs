using RollAndRecord.Core.Models;

namespace RollAndRecord.Core.Interfaces.Repositories
{
    public interface IExpenseRepository : IBaseRepository<Expense>
    {
        Task<List<Expense>> GetExpensesByType(ExpenseType type);
    }
}
