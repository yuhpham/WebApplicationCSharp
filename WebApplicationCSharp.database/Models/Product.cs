using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCSharp.database.Models
{
    [Table("product")]
    public class Product : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; } = string.Empty;                    
        public string Images { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Unit { get; set; } = "VND";
        public int Quantity { get; set; } = 0;
    }
}
