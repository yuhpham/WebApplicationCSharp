using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public interface IProductService
    {
        Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request);
        Task<ProductGetListResponse> PostProductPostList(ProductGetListRequest request);
        Task<ProductGetListResponse> PutProductPutList(ProductGetListRequest request);
        Task<ProductGetListResponse> DeleteProductDeleteList(ProductGetListRequest request);

    }
}
