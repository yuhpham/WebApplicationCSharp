using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.database.Interface;

namespace WebApplicationCSharp.database.Models
{
    [Table("cart")]
    public class Cart : BaseEntity ,ITransform<Cart>
    {
        [Column("Products")]             
        public  string ListProducts { get; set; } = string.Empty;

        public Cart Transform()
        {
            return new Cart()
            {
                Id = Id,
                ListProducts = ListProducts,                
            };
        }
    }
}
