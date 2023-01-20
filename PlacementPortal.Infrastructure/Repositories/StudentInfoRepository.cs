using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class StudentInfoRepository : GenericRepository<StudentInfo>, IStudentInfoRepository
    {
        public StudentInfoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
