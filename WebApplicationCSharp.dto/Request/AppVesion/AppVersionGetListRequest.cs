using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.dto.Request.AppVesion
{
    public class AppVersionGetListRequest : IPagingRequest
    {
        public int PageIndex { get; set; } = 10;
        public int PageSize { get; set; } = 1;

        public string Version { get; set; } = string.Empty;
    }
}
