namespace WebApplicationCSharp.dto.Request
{
    public interface IPagingRequest
    {   
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
