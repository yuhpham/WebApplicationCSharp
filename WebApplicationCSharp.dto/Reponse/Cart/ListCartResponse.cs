using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationCSharp.dto.Reponse.Product;

namespace WebApplicationCSharp.dto.Reponse.Cart
{
    public class ListCartResponse
    {
        public Guid UserId { get; set; }
        public List <ProductResponse> ListProducts { get; set; } = new List <ProductResponse> ();
        
        /// <summary>
        /// Page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page Index
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Total
        /// </summary>
        public double TotalPrice { get; set; } // bonus

        /// <summary>
        /// Data return
        /// </summary>
    }
}
