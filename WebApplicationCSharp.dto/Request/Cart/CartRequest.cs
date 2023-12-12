using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.dto.Request.Cart
{
    public class CartRequest
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; } 

        
    }
}
