using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationCSharp.database.Models
{
    [Table("appversion")]
    public class AppVersion : BaseEntity
    {
        public string Version { get; set; } = string.Empty;
    }
}
