using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public interface IProductService
    {
        Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request);
        Task InsertProduct(ProductGetListRequest request);
        Task UpdateProduct(ProductGetListRequest request);
        Task DeleteProduct(ProductGetListRequest request);

    }
}
