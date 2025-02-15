using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RollAndRecord.Core.Models
{
    [Table("Customers")]
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }
        public string Firstname { get; set; } = "";
        public string Name { get; set; } = "";

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Sale>? Purchases { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Payment>? Payments { get; set; }
        public decimal? Balacance => Purchases?.Sum(p => p.Amount) - Payments?.Sum(p => p.Amount);
    }
}
