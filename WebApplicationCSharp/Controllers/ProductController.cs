using Microsoft.AspNetCore.Mvc;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;
using WebApplicationCSharp.Service.LogInService;
using WebApplicationCSharp.Service.ProductService;

namespace WebApplicationCSharp.Controllers
{
    [Route("api/Product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILoggingService _loggingService;
        private readonly ProductService _ProductService;
        public ProductController()
        {
            _ProductService = new ProductService();
            _loggingService = new LoggingService();
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
               
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);

            }
        }
        [Route("post-product")]

        [HttpPost()]

        public async Task<IActionResult> PostProducts(Product request)
        {
            throw new NotImplementedException();
           
        }
        [Route("put-prodct")]
        [HttpPut()]
        public async Task<IActionResult> PutProduct(Product request)
        {

            throw new NotImplementedException();
        }

    }
}
