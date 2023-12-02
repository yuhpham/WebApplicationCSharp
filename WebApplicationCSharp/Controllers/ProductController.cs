using Microsoft.AspNetCore.Mvc;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;
using WebApplicationCSharp.Service.ProductService;

namespace WebApplicationCSharp.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ProductService;
        public ProductController()
        {
            _ProductService = new ProductService();
        }


        [Route("get-product")]

        [HttpGet()]
        public async Task<IActionResult> GetProducts([FromQuery] ProductGetListRequest request)
        {
            try
            {
                ProductGetListResponse reponse = await _ProductService.GetProductGetList(request);

                return new JsonResult(reponse);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return StatusCode(500, ex.Message);

            }
        }
        [Route("post-product")]

        [HttpPost()]

        public async Task<IActionResult> PostProducts(Product product)
        {
            try
            {
                await _ProductService.PostProductPostList(product);

                return new JsonResult(product);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return StatusCode(500, ex.Message);

            }




        }

    }
}
