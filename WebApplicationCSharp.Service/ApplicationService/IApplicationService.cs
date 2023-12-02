using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;



namespace WebApplicationCSharp.Service.ApplicationService
{
    public interface IApplicationService
    {
        /// <summary>
        /// Get application by version string
        /// </summary>
        /// <param-name="request"></param>
        /// <returns></returns>
        Task<AppVersionGetListResponse> GetAppVersionGetList(AppVersionGetListRequest request);





    }
}
