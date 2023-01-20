using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class Course : EntityBase
    {
        public string Name { get; set; } = null!;
        public int Duration { get; set; }
    }
}
