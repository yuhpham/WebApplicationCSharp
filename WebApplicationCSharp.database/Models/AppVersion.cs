using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.database.Models
{
    [Table("appversion")]
    public class AppVersion : BaseEntity
    {
        public string Version { get; set; } = string.Empty;
    }
}
