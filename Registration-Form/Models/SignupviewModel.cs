using System.ComponentModel.DataAnnotations;

namespace Registration_Form.Models
{
    public class SignupviewModel
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(250)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}
