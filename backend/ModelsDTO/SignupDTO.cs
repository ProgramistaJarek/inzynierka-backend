using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace backend.ModelsDTO
{
    public class SignupDTO
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        
        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
