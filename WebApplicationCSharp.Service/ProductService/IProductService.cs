using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public interface IProductService
    {
        Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request);
        Task<ProductGetIdResponse> GetIdProduct(ProductGetIdRequest request);
        Task<Boolean> CreateProduct(ProductCreateRequest request);
        Task<ProductUpdateReponse> UpdateProduct(ProductUpdateRequest request);
      
       
      

    }
}
