using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Silicon.Models
{
    public class SignUpViewModel
    {
        [Display(Name = "First name", Prompt = "Enter your first name")]
        [Required(ErrorMessage = "Enter a valid first name")]
        [MinLength(2, ErrorMessage = "Enter a valid first name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last name", Prompt = "Enter your last name")]
        [Required(ErrorMessage = "Enter a valid last name")]
        [MinLength(2, ErrorMessage = "Enter a valid last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email address", Prompt ="Enter your Email address")]
        [Required(ErrorMessage = "A valid email address is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your password")]
        [Required(ErrorMessage = "Enter a valid password")]
        [MinLength(8, ErrorMessage = "A valid password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password", Prompt = "Confirm your password")]
        [Required(ErrorMessage = "Password must be confirmed")]
        [Compare(nameof(Password), ErrorMessage = "Password don't match")]
        public string ConfirmPassword { get; set; } = null!;

        [Display(Name = "I agree to the Terms & Conditions.")]
        public bool TermsAndConditions { get; set; }
    }
}
