using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public interface IProductService
    {
        Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request);
        Task<ProductGetIdResponse> GetIdProduct(IdProductRequest request);
        Task<ProductResponse> InsertProduct(ProductRequest request);
        Task<ProductResponse> UpdateProduct(ProductRequest request);
        Task<ProductResponse> DeleteProduct(IdProductRequest request);

    }
}
