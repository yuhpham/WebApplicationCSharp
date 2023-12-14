using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
        private readonly IProductService _productService;
        private readonly ILoggingService _loggingService;


        public ProductController()
        {
            _productService = new ProductService();
            _loggingService = new LoggingService();
        }

        [Route("get-Id-product")]

        [HttpGet()]

        public async Task<ActionResult> GetIdProduct([FromQuery] Guid Id)
        {
            try
            {

                ProductResponse response = await _productService.GetProductId(Id);
                _loggingService.LogInfo(JsonSerializer.Serialize(response));
                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }


        [Route("get-product")]

        [HttpGet()]
        public async Task<IActionResult> GetListProduct([FromQuery] ProductGetListRequest request)
        {
            try
            {
                ProductGetListResponse response = await _productService.GetProductGetList(request);

                return new JsonResult(response);

            }
            catch (Exception ex)
            {

                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);

            }
        }
        [Route("post-product")]

        [HttpPost()]
        public async Task<ActionResult> PostProduct([FromQuery] ProductCreateRequest request)
        {
            try
            {
                await _productService.CreateProduct(request);
                return Ok();


            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }

        [Route("put-product")]

        [HttpPut()]
        public async Task<ActionResult> PutProduct([FromQuery] ProductUpdateRequest request)
        {
            try
            {
                ProductResponse response = await _productService.UpdateProduct(request);
                return new JsonResult(response);


            }
            catch (Exception ex)
            {
                _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }


    }
}
