using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacementPortal.Model.Models
{
    public class CollegeModel
    {   
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
