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
        public DbSet<College> College { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyRequest> CompanyRequest { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<InterviewStatus> InterviewStatus { get; set; }
        public DbSet<PlacementProcess> PlacementProcess { get; set; }
        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<StudentStatus> StudentStatus { get; set; }
        public DbSet<UserType> UserType { get; set; }
    }
}
