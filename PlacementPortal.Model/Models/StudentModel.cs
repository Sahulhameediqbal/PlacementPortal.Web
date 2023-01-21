using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementPortal.Model.Models
{
    public class StudentModel
    {
        public string Name { get; set; } = null!;
        public Guid CollegeId { get; set; }
        public Guid DepartmentId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Rollumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTimeOffset DOB { get; set; }
        public int CourseStart { get; set; }
        public int CourseEnd { get; set; }
        public decimal CGPA { get; set; }
        public string Address { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}
