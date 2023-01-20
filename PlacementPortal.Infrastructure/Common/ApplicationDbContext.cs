using Microsoft.EntityFrameworkCore;
using PlacementPortal.Domain.Entities;

namespace PlacementPortal.Infrastructure.Common
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 

        }
        public DbSet<User> User { get; set; }
    }
}
