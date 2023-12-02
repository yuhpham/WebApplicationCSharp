namespace WebApplicationCSharp.dto.Reponse.Appversion
{
    public class AppVersionGetListResponse
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
        /// Data return
        /// </summary>
        public List<AppVersionResponse> Data { get; set; } = [];

        public long Total { get; set; } // bonus
    }
}
