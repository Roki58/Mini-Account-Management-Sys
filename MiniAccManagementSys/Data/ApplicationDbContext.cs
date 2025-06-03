using Microsoft.EntityFrameworkCore;
using MiniAccManagementSys.Models;

namespace MiniAccManagementSys.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<ChartOfAccount> ChartOfAccounts { get; set; }

    }
}
