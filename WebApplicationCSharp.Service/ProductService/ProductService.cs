using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public class ProductService : IProductService
    {


        public async Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request)
        {

            ProductGetListResponse productGetListResponse = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,

            };

            using ApplicatitonContext context = new();

            IQueryable<Product> query = context.Products.Where(a => a.Name.Contains(request.Name));

            productGetListResponse.DataProduct = await query
                  .Skip(request.PageSize * (request.PageIndex - 1))
                  .Take(request.PageSize)
                  .Select(a => new ProductResponse
                  {
                      Id = a.Id,
                      Name = a.Name,
                      Category = a.Category,
                      Images = a.Images,
                      Price = a.Price,
                      Unit = a.Unit,
                      Quantity = a.Quantity
                  }).ToListAsync();

            productGetListResponse.Total = query.Count();

            return productGetListResponse;
        }
        public  Task InsertProduct(ProductGetListRequest request)
        {

            using ApplicatitonContext context = new();

            return Task.CompletedTask;
           
        }

        public Task UpdateProduct(ProductGetListRequest request)
        {
            throw new NotImplementedException();
        }
        public Task DeleteProduct(ProductGetListRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
