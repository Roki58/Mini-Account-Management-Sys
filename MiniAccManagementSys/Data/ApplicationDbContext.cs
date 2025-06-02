using Microsoft.EntityFrameworkCore;

namespace MiniAccManagementSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // Define DbSets for your entities here, e.g.:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
  
}
