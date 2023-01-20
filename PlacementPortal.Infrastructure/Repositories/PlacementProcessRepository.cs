using PlacementPortal.Application.Interfaces.Repositories;
using PlacementPortal.Domain.Entities;
using PlacementPortal.Infrastructure.Common;

namespace PlacementPortal.Infrastructure.Repositories
{
    public class PlacementProcessRepository : GenericRepository<PlacementProcess>, IPlacementProcessRepository
    {
        public PlacementProcessRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
