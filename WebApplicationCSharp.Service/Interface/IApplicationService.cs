using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;



namespace WebApplicationCSharp.Service.Interface
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
