using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationCSharp.database.Interface;

namespace WebApplicationCSharp.database.Models
{
    [Table("product")]
    public class Product : BaseEntity, ITransform<Product>
    {
        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        public string Images { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Unit { get; set; } = "VND";
        public int Quantity { get; set; } = 0;

        public Product Transform()
        {
            return new Product
            {
                Id = Id,
                Name = Name,
                Images = Images,
                Price = Price,
                Unit = Unit,
                Quantity = Quantity,
                Category = Category,
                CreatedAt = CreatedAt,
            };
        }
    }
}
