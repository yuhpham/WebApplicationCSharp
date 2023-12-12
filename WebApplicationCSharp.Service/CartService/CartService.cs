using Azure;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Net.Http;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.Cart;
using WebApplicationCSharp.dto.Request.Product;

namespace WebApplicationCSharp.Service.CartService
{
    public class CartService : ICartService
    {
        public Task<ListCartResponse> GetCart(Guid cartId)
        {

            ListCartResponse listCartResponse = new()
            {
                PageSize = 10,
                PageIndex = 1
            };
            using (ApplicatitonContext context = new())
            {
                if (context.Carts != null)
                {
                    Cart? cart = context.Carts.Find(cartId);
                    if (cart != null)
                    {
                        CartResponse cartResponse = new CartResponse
                        {
                            UserId = cart.Id,
                            ListProducts = cart.ListProducts
                        };

                        List<string> result = cartResponse.ListProducts.Split(';').ToList();
                        foreach (string id in result)
                        {
                            Guid Id = new Guid(id);
                            if (context.Products != null)
                            {
                                Product? product = context.Products.Find(Id);
                                if (product != null)
                                {
                                    ProductResponse productResponse = new()
                                    {
                                        Id = Id,
                                        Name = product.Name,
                                        Category = product.Category,
                                        Images = product.Images,
                                        Price = product.Price,
                                        Unit = product.Unit,
                                        Quantity = product.Quantity,
                                        CreatedAt = product.CreatedAt
                                    };


                                    listCartResponse.ListProducts.Add(productResponse);

                                }
                            }
                        }
                        listCartResponse.TotalPrice = listCartResponse.ListProducts.Sum(p => double.Parse(p.Price));

                    }
                }
            }
            return Task.FromResult(listCartResponse);
        }
        public async Task<CartResponse> AddToCart(CartRequest request)
        {
            throw new NotImplementedException();
           
        }
        public async Task<bool> InsertCart(CartRequest request)
        {

            ApplicatitonContext context = new();
            if (context.Carts != null)
            {
                Cart cart = new()
                {
                    Id = request.UserId,
                    ListProducts = request.ProductId.ToString()
                };
                await context.Carts.AddAsync(cart);
                int i = await context.SaveChangesAsync(); //save change trả về int
                return i > 0;
            }
            return false;
        }
        public async Task<bool> UpdateCart(CartRequest request)
        {

            using (ApplicatitonContext context = new())
            {
                if (context.Carts != null)
                {
                    Cart? cart = context.Carts.Find(request.UserId);

                    if (cart != null)
                    {
                        string newProdcut = "," + request.ProductId;
                        cart.ListProducts = cart.ListProducts + newProdcut;
                        await context.Carts.AddAsync(cart);
                        await context.SaveChangesAsync();
                        return await context.SaveChangesAsync() > 0;
                    }
                }
            }
            return false;
        }

       
    }
}
