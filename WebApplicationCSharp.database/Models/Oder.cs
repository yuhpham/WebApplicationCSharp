using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCSharp.database.Models
{
    [Table("oder")]
    public class Oder : BaseEntity
    {
        public string ListProduct { get; set; } = string.Empty;
        public int Total { get; set; }
        public decimal TotalPice { get; set; }
        public Guid UserID { get; set; }
    }
}
