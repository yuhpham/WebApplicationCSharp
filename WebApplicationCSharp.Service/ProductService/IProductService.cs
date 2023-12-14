using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public interface IProductService
    {
        Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request);
        Task<ProductResponse> GetProductId(Guid Id);
        Task<Boolean> CreateProduct(ProductCreateRequest request);
        Task<ProductResponse> UpdateProduct(ProductUpdateRequest request);
        Task<Boolean> DeleteProduct(Guid Id);




    }
}
