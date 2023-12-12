using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Cart;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.CartService
{
    public interface ICartService
    {
        Task<CartResponse> AddToCart(CartRequest request);

        Task<ListCartResponse> GetCart(Guid cartId);

    }
}
