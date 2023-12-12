namespace WebApplicationCSharp.dto.Reponse.User
{
    public class UserGetListResponse
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
        /// 
        public List<UserResponse> userGetListResponse { get; set; } = new List<UserResponse>();

        public int Total { get; set; }
    }
}
