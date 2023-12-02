namespace WebApplicationCSharp.dto.Reponse.Product
{
    public class ProductGetListResponse
    {
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page Index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public long Total { get; set; } // bonus

        /// <summary>
        /// Data return
        /// </summary>
        public List<ProductResponse> DataProduct { get; set; } = [];


    }
}
