using SQLite;

namespace RollAndRecord.Core.Models
{
    [Table("EquipmentExpenses")]
    public class EquipmentExpense : Expense
    {
        public string Name { get; set; } = "";
    }
}
