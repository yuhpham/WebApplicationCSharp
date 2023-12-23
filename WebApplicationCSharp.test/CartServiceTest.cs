using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.Service.CartService;

namespace WebApplicationCSharp.test
{
    [TestClass]
    public class CartServiceTest
    {
        private ICartService _cartService;

        public CartServiceTest()
        {
            _cartService = new CartService();
        }

        [TestMethod]
        public async Task GetCartTest()
        {
            Guid id = Guid.NewGuid();
            ListCartResponse listCartResponse = await _cartService.GetCart(id);
            Assert.IsNotNull(listCartResponse);

        }

    }
}
