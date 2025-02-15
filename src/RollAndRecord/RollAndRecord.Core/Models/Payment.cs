using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RollAndRecord.Core.Models
{
    [Table("Payments")]
    public class Payment
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(typeof(Customer))]
        public Guid CustomerId { get; set; }
    }
}
