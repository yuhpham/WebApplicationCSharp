using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.database.Models
{
    [Table("cart")]
    public class Cart : BaseEntity
    {
        [Column("userId")]
        public Guid UserId {  get; set; }   
        public List <Product> ListProductId { get; set; }=new List<Product>();
        public bool IsCheckOut { get; set; }

    }
}
