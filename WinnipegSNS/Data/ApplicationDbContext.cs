using Microsoft.EntityFrameworkCore;
using WinnipegSNS.Models;

namespace WinnipegSNS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
