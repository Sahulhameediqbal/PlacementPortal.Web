using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class StudentStatusRepository : GenericRepository<StudentStatus>, IStudentStatusRepository
    {
        public StudentStatusRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
