using SQLite;

namespace RollAndRecord.Core.Models
{
    [Table("Expenses")]
    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public decimal Cost { get; set; }
        public decimal? Quantity { get; set; }

        public ExpenseType Type { get; set; }

        // Equipment-specific properties
        public string? EquipmentName { get; set; }

        // Tobacco-specific properties
        public string? TobaccoName { get; set; }
        public decimal? PricePerKg { get; set; }
        public decimal? Weight { get; set; }

        // Computed property for Tobacco total cost
        public decimal? TotalCost => Type == ExpenseType.Tobacco && PricePerKg.HasValue && Weight.HasValue
            ? PricePerKg.Value * Weight.Value
            : null;
    }
}
