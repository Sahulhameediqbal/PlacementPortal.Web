namespace PlacementPortal.Model.Models
{
    public class AuthenticationModel
    {
        public Guid Id { get; set; }        
        public string Email { get; set; } = null!;
        public string UserType { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Guid ComapanyId { get; set; }
        public Guid CollegeId { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}
