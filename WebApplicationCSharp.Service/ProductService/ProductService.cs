﻿using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.ProductService
{
    public class ProductService : IProductService
    {


        public async Task<ProductGetIdResponse> GetProductId(Guid Id)
        {
            ProductGetIdResponse response = new();
            await using (ApplicatitonContext context = new())

            {
                Product? product = context.Products.Find(Id);
                if (product != null)
                {
                    response.productGetIdReponse = new()
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
            ProductGetListResponse response = new()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,

            };
            using (ApplicatitonContext context = new())
            {

                IQueryable<Product> query = context.Products.Where(a => a.Name.Contains(request.Name));

                response.productGetListResponse = await query
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
                          CreatedAt = a.CreatedAt,
                      }).ToListAsync();

                response.Total = query.Count();
            }

            return response;
        }
        public async Task<Boolean> CreateProduct(ProductCreateRequest request)
        {
            using (ApplicatitonContext context = new())
            {
                Product product = new()
                {
                    Name = request.Name,
                    Category = request.Category,
                    Images = request.Images,
                    Price = request.Price,
                    Unit = request.Unit,
                    Quantity = request.Quantity,

                };
                context.Products.Add(product);
                int y = await context.SaveChangesAsync();

                return y > 0;

            }

        }
        public async Task<ProductUpdateReponse> UpdateProduct(ProductUpdateRequest request)
        {

            using (ApplicatitonContext context = new())

            {
                if(context.Products!= null)
                {
                    Product? product = context.Products.Find(request.Id);
                    if (product != null)
                    {
                        if (request.Name != null) { request.Name = product.Name; }
                        if (request.Category != null) { request.Category = product.Category; }
                        if (request.Images != null) { request.Images = product.Images; }
                        if (request.Price != null) { request.Price = product.Price; }
                        if (request.Unit != null) { request.Unit = product.Unit; }
                        _ = context.Products.Update(product);
                        _ = await context.SaveChangesAsync();

                    }
                }
                return ?
                
            }
         

        }
    }
}
