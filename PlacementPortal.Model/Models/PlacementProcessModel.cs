namespace PlacementPortal.Model.Models
{
    public class PlacementProcessModel
    {
        public Guid Id { get; set; }
        public Guid CompanyRequestId { get; set; }
        public Guid StudentId { get; set; }
        public bool IsActive { get; set; }
    }
}
