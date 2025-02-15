using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RollAndRecord.Core.Models
{
    [Table("Sales")]
    public class Sale
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey(typeof(Customer))]
        public Guid CustomerId { get; set; }

        [ForeignKey(typeof(SaleType))]
        public Guid SaleTypeId { get; set; }
    }
}
