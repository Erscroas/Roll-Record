using SQLite;

namespace RollAndRecord.Core.Models
{
    [Table("SaleTypes")]
    public class SaleType
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string TypeName { get; set; } = "";
    }
}
