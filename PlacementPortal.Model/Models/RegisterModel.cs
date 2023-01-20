using System.ComponentModel.DataAnnotations;

namespace PlacementPortal.Model.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public string Name { get; set; }
    }
}
