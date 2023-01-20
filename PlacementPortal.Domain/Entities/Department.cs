using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class Department : EntityBase
    {
        public string Name { get; set; } = null!;
        public Guid CourseId { get; set; }
    }
}
