using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;
using WebApplicationCSharp.Service.ProductService;

namespace WebApplicationCSharp.test
{
    [TestClass]
    public class ProductServiceTest
    {
        private readonly IProductService _productService;

        public ProductServiceTest()
        {
            _productService = new ProductService();
        }

        /// <summary>
        /// GetApplicationVersionList happy case request
        /// </summary>
        [TestMethod]
        public async Task GetProductListTestAsync()
        {
            // Input
            ProductGetListRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,

            };
            // Output
            ProductGetListResponse response = await _productService.GetProductGetList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.productGetListResponse.Count > 0); // response data > 0
        }

        /// <summary>
        /// GetApplicationVersionListWithVersion exception case request
        /// </summary>
        [TestMethod]
        public async Task GetProductListProductTestAsync()
        {
            // Input
            ProductGetListRequest request = new()
            {
                PageIndex = 1,
                PageSize = 10,
                Name = "Product 45039",
            };
            // Output
            ProductGetListResponse response = await _productService.GetProductGetList(request);
            Assert.IsNotNull(response); // response not null
            Assert.IsTrue(response.productGetListResponse.Count == 1); // response data > 0
        }
        [TestMethod]
        public async Task PostProductTestAsync()
        {
            // Input
            ProductCreateRequest request = new()
            {
                Name = "name",
                Category = "category",
                Price = "2000",
                Unit = "VND"
            };
            // Output
            bool i = await _productService.CreateProduct(request);
            Assert.IsNotNull(i);
            Assert.IsTrue(i);
        }
        [TestMethod]
        public async Task UpdateProduct()
        {
            ProductCreateRequest request = new()
            {
                Name = "name",
                Category = "category",
                Price = "Price",
                Unit = "VND"
            };
            bool i = await _productService.CreateProduct(request);
            Assert.IsNotNull(i);
            Assert.IsTrue(i);

        }
    }
}
