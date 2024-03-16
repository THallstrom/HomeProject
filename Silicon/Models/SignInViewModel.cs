using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class SignInViewModel
    {
        [Display(Name = "Email address", Prompt = "Enter your Email address")]
        [Required(ErrorMessage = "A valid email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your password")]
        [Required(ErrorMessage = "Enter a valid password")]
        [MinLength(8, ErrorMessage = "A valid password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "I agree to the Terms & Conditions.")]
        public bool RememberMe { get; set; }
    }
}
