using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.dto.Request.Product
{
    public class ProductGetIdRequest
    {
        public Guid Id { get; set; } = Guid.Empty;

    }
}
