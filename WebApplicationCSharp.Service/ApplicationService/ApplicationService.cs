using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.Service.Interface;

namespace WebApplicationCSharp.Service.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        public async Task<AppVersionGetListResponse> GetAppVersionGetList(AppVersionGetListRequest request)
        {
            AppVersionGetListResponse appVersionGetListResponse = new AppVersionGetListResponse()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };
            using (ApplicatitonContext context = new ApplicatitonContext())
            {
                IQueryable<AppVersion> query = context.AppVersions.Where(a => a.Version.Contains(request.Version));
                appVersionGetListResponse.Data = await query.Select(a => new AppVersionResponse
                {
                    Id = a.Id,
                    Version = a.Version
                }).ToListAsync();
            }
            return appVersionGetListResponse;

        }


    }
}
