using PlacementPortal.Shared.Common;

namespace PlacementPortal.Domain.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public Guid UserTypeId { get; set; }
        public bool IsActive { get; set; }       
        
        public virtual Company Company { get; set; }
        public virtual College College { get; set; }
    }
}
