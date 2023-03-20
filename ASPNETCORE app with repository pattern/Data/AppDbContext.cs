using ASPNETCORE_app_with_repository_pattern.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCORE_app_with_repository_pattern.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
