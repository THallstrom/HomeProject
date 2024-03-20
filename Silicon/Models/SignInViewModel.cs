using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class SignInViewModel
    {
        [Display(Name = "Email address", Prompt = "Enter your Email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Password", Prompt = "Enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
