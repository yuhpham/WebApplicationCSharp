using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public class ProductService : IProductService
    {
        public Task<ProductGetListResponse> DeleteProductDeleteList(ProductGetListRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request)
        {

            ProductGetListResponse productGetListResponse = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,

            };

            using (ApplicatitonContext context = new ApplicatitonContext())

            {
                var query2 = context.Products;
                IQueryable<Product> query = context.Products
                    .Where(a => a.Name.Contains(request.Name))
                   .Skip(request.PageSize * (request.PageIndex - 1))
                    .Take(request.PageSize);

                productGetListResponse.Total = query2.Count();

                productGetListResponse.DataProduct = await query.Select(a => new ProductResponse
                {
                    Id = a.Id,
                    Name = a.Name,
                }).ToListAsync();

                return productGetListResponse;

            }
        }

        public async Task<ProductGetListResponse> PostProductPostList(ProductGetListRequest request)
        {
            ProductGetListResponse productGetListResponse = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

            Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
                Images = request.Images,
                Quantity = request.Quantity
            };
            using ApplicatitonContext context = new ApplicatitonContext();

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            return productGetListResponse;
        }

        public Task PostProductPostList(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductGetListResponse> PutProductPutList(ProductGetListRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
