namespace PlacementPortal.Web.Models
{
    public class LoginStatus
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
    }
}
