namespace PlacementPortal.Model.Models
{
    public class DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CourseId { get; set; } 
    }
}
