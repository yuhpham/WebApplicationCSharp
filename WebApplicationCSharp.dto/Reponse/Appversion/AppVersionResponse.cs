using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.dto.Reponse.Appversion
{
    public class AppVersionResponse
    {
        public Guid Id { get; set; }
        public string Version { get; set; } = string.Empty;

    }
}
