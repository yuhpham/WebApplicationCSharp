using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.database;
using WebApplicationCSharp.database.Models;
using WebApplicationCSharp.dto.Reponse;
using WebApplicationCSharp.dto.Reponse.Appversion;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.Service.Interface;

namespace WebApplicationCSharp.Service
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
