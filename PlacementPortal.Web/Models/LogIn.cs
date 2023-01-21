using System.ComponentModel.DataAnnotations;

namespace PlacementPortal.Web.Models
{
    public class LogIn
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
