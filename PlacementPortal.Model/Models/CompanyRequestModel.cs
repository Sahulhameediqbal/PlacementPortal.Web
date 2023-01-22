namespace PlacementPortal.Model.Models
{
    public class CompanyRequestModel
    {
        public Guid Id { get; set; }
        //public string Code { get; set; } = null!;
        public Guid CompanyId { get; set; }
        public Guid CollegeId { get; set; }
        public DateTimeOffset RecuritmentDate { get; set; }
        public Guid DepartmentId { get; set; }
        public decimal MinimumPercenage { get; set; }
        public int NoofInterviewRound { get; set; }
        public int NoOfRequirement { get; set; }
        public string Comments { get; set; } = null!;
        public bool Status { get; set; }
        public bool CollegeResponse { get; set; }        
    }
}
