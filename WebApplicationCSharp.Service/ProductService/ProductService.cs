using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public class ProductService : IProductService
    {
       
       
        public async Task <ProductGetIdResponse> GetIdProduct(ProductGetIdRequest request)
        {
            ProductGetIdResponse response = new();
            using (ApplicatitonContext context = new())

            {
                Product product = context.Products.Find(request.Id);
                if (product != null)
                {
                    response.ProductGetIdReponse = new()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Category = product.Category,
                        Images = product.Images,
                        Price = product.Price,                      
                        Unit = product.Unit,
                        Quantity = product.Quantity,
                        CreatedAt = product.CreatedAt,
                    };


                }
                else
                {
                    Console.WriteLine(" not found ");
                }


            }

            return response;

        }

        public async Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request)
        {

            ProductGetListResponse productGetListResponse = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,

            };

            using (ApplicatitonContext context = new())
            {

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
                          Quantity = a.Quantity,
                          CreatedAt= a.CreatedAt,
                          

                      }).ToListAsync();


                productGetListResponse.Total = query.Count();
            }

            return productGetListResponse;
        }

        public Task<ProductResponse> InsertProduct(ProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UpdateProduct(ProductRequest request)
        {
            throw new NotImplementedException();
        }
        public Task<ProductResponse> DeleteProduct(ProductGetIdRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
