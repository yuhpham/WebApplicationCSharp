using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.dto.Request.Cart;

namespace WebApplicationCSharp.Service.CartService
{
    public interface ICartService
    {
        Task<ListCartResponse> AddToCart(CartRequest request);

        Task<ListCartResponse> GetCart(Guid cartId);

    }
}
