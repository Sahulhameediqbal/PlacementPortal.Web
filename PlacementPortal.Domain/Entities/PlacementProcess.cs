using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class PlacementProcess : EntityBase
    {
        public Guid CompanyRequestId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsActive { get; set; }
    }
}
