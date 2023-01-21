namespace PlacementPortal.Model.Models
{
    public class StudentStatusModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
