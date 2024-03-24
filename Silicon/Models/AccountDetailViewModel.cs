using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class AccountDetailViewModel
    {
        [Display(Name = "Firstname", Prompt ="Enter your name")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Lastname", Prompt = "Enter your last name")]
        [DataType(DataType.Text)]
        public string LastName { get; set; } = null!;

        [Display(Name = "Email", Prompt = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Display(Name = "Phone", Prompt = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        [Display(Name = "Addressline 1", Prompt = "Enter your address")]
        [DataType(DataType.Text)]
        public string? Addressline1 { get; set; }

        [Display(Name = "Addressline 2", Prompt = "Enter your address")]
        [DataType(DataType.Text)]
        public string? Addressline2 { get; set; }

        [Display(Name = "Postal code", Prompt = "Enter your postal code")]
        [DataType(DataType.PostalCode)]
        public string? PostalCode { get; set; } 

        [Display(Name = "City", Prompt = "Enter your city")]
        [DataType(DataType.Text)]
        public string? City { get; set; } 


    }
}
