namespace WebApplicationCSharp.dto.Reponse.Cart
{
    public class CartResponse
    {
        public Guid UserId { get; set; }
        public string ListProducts { get; set; } = string.Empty;
    }
}
