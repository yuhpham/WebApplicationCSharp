using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
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
using WebApplicationCSharp.dto.Reponse.Product;
using WebApplicationCSharp.dto.Request.AppVesion;
using WebApplicationCSharp.dto.Request.Product;
using WebApplicationCSharp.Service.Interface;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<ProductGetListResponse> GetProductGetList(ProductGetListRequest request)
        {

            ProductGetListResponse productGetListResponse = new ProductGetListResponse()
            {
                PageIndex = request.PageIndex,
                PageSize = request.PageSize
            };

            using (ApplicatitonContext context = new ApplicatitonContext())
            {
                IQueryable<Product> query = context.Products.Where(a => a.Name.Contains(request.Name));
                productGetListResponse.DataProduct = await query.Select(a => new ProductResponse
                {
                    Id = a.Id,
                    Name = a.Name,


                }).ToListAsync();
                return productGetListResponse;

            }
        }
    }
}
