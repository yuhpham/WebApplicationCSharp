using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.dto.Request
{
    public interface IPagingRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
