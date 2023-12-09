using Microsoft.AspNetCore.Mvc;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;
using WebApplicationCSharp.Service.LogInService;
using WebApplicationCSharp.Service.ProductService;
using System.Text.Json;
using Azure;

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

        public async Task<ActionResult> GetIdProduct([FromQuery] ProductGetIdRequest request)
        {

            try
            {

                ProductGetIdResponse response = await _productService.GetIdProduct(request);
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
        public async Task<IActionResult> GetProducts([FromQuery] ProductGetListRequest request)
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
        [Route("put-product")]

        [HttpGet()]
        public async Task <ActionResult> PutProduct(ProductCreateRequest request)
        {
            try
            {
                await _productService.CreateProduct(request);
                return Ok();
               

            }
            catch (Exception ex) 
            { _loggingService.LogError(ex);
                return StatusCode(500, ex.Message);
            }
        }


    }
}
