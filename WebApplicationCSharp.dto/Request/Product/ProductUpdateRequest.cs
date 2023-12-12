using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.dto.Request.Product
{
    public class ProductUpdateRequest
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public int Quantity { get; set; } = 0;
        public string Unit { get; set; } = "VND";
        public string Images { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
