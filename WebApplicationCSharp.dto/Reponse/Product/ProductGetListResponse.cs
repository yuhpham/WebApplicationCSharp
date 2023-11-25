using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Appversion;

namespace WebApplicationCSharp.dto.Reponse.Product
{
    public class ProductGetListResponse
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
        public List<ProductResponse> DataProduct { get; set; } = new List<ProductResponse>();

        public long Total { get; set; } // bonus
    }
}
