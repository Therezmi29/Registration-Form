using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models
{
    public class LoginViewModel
    {
        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
