namespace WebApplicationCSharp.dto.Request.Product
{
    public class ProductGetListRequest : IPagingRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Unit { get; set; } = "VND";
        public string Images { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
