using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class CompanyRequestRepository : GenericRepository<CompanyRequest>, ICompanyRequestRepository
    {
        public CompanyRequestRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
