using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class UserDetailModel
    {
        [Display(Name = "Firstname", Prompt = "Enter your name")]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }

        [Display(Name = "Lastname", Prompt = "Enter your last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email", Prompt = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone", Prompt = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }


    }
}
