using System.Net.Http;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Cart;
using WebApplicationCSharp.dto.Reponse.Product;

namespace WebApplicationCSharp.Service.CartService
{
    public class CartService 
    {
        private ApplicatitonContext context = new ApplicatitonContext();

        public Cart GetCartById(Guid cartId)
        {
            Cart cart =context.Carts.First(x => x.Id == cartId);

            cart.ListProductId = context.Products.Where(x => x.Id == cartId).ToList();          
            
                
            
            return cart;
        }





    }
}
