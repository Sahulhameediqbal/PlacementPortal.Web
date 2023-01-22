using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class UserDetail : EntityBase
    {
        public Guid UserId { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
