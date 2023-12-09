using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Product;

namespace WebApplicationCSharp.dto.Reponse.Cart
{
    public class CartResponse
    {
        public Guid Guid { get; set; }
        public Guid UserId { get; set; }    
        public List<ProductResponse> ListProduct { get; set; } = new List<ProductResponse>();
    }
}
