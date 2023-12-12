using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Cart;
using WebApplicationCSharp.Service.CartService;
using WebApplicationCSharp.Service.LogInService;

namespace WebApplicationCSharp.Controllers
{
    [Route("api/Cart")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly ILoggingService _loggingService;
        public CartController()
        {
            _cartService = new CartService();
            _loggingService = new LoggingService();
        }

        [Route("add-Cart")]

        [HttpGet()]

        public async Task<ActionResult> AddProductToCart([FromQuery] CartRequest request)
        {
            try
            {
                CartResponse cartResponse = await _cartService.AddToCart(request);
                return new JsonResult(cartResponse);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }

        }

        [Route("get-cart")]
        [HttpGet]
        public async Task<IActionResult> getCart([FromQuery] Guid userID)
        {
            try
            {
                ListCartResponse response = await _cartService.GetCart(userID);
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                // send to logging service
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }

        }
    }
}
