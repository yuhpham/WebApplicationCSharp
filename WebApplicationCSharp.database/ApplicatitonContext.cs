using Microsoft.EntityFrameworkCore;
using WebApplicationCSharp.database.Models;

namespace WebApplicationCSharp.database
{
    public class ApplicatitonContext : DbContext

    {
        public DbSet<AppVersion> AppVersions { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Oder> Oders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=vuavechai_;User Id=vuavechai_;Password=z12312345;TrustServerCertificate=true;");
        }
    }
}
