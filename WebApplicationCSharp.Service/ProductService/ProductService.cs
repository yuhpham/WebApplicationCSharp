using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly ApplicatitonContext _context = new();

        public ProductService(ApplicatitonContext context)
        {
            _context = context;
        }

        public  async Task<ProductGetIdResponse> GetIdProduct(IdProductRequest request)
        {
            ProductGetIdResponse response = new();
            try
            {
                
                if (_context != null && _context.Products != null)
                {
                    Product product = await _context.Products.FindAsync(request.Id);
                    if (product != null)
                    {
                        response.ProductGetIdReponse = new()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Category = product.Category,
                            Images = product.Images,
                            Price = product.Price,
                            Quantity = product.Quantity,
                            Unit = product.Unit,
                            CreatAt = product.CreateAt

                        };
                      

                    }
                    else
                    {
                        Console.WriteLine(" not found");
                    }

                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);  
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

           

            IQueryable<Product> query = _context.Products.Where(a => a.Name.Contains(request.Name));

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
                      CreatAt = a.CreateAt
                     
                  }).ToListAsync();

            productGetListResponse.Total = query.Count();

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
        public Task<ProductResponse> DeleteProduct(IdProductRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
