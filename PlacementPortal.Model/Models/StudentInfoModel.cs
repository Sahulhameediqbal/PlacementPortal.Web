namespace PlacementPortal.Model.Models
{
    public class StudentInfoModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CollegeId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string RollNumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTimeOffset DOB { get; set; }
        public int CourseStart { get; set; }
        public int CourseEnd { get; set; }
        public decimal CGPA { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
        public List<CollegeModel> Colleges { get; set; }
    }
}
