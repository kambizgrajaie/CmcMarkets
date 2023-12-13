using CmcMarkets.Backend.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CmcMarkets.Backend.Persistence
{
    public class ApplicationDbContext : IdentityDbContext, IDataContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserTask> UserTasks { get; set; }
    }
}
