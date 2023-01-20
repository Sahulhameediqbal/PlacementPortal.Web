using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class CollegeRepository : GenericRepository<College>, ICollegeRepository
    {
        public CollegeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
