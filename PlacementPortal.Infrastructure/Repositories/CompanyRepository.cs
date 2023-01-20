using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
