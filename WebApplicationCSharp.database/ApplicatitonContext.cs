using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database.Models;

namespace WebApplicationCSharp.database
{
    public class ApplicatitonContext : DbContext

    {
        public DbSet<AppVersion> AppVersions { get; set; }


        public DbSet<Product> Products { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Data Source=sql.bsite.net\\MSSQL2016;User ID=vuavechai_;Password=z12312345;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
