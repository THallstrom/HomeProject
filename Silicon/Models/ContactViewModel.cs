using System.ComponentModel.DataAnnotations;

namespace Silicon.models;

public class ContactViewModel
{
    [Display(Name = "Full name", Prompt = "Enter your full name")]
    [DataType(DataType.Text)]
    public string FullName { get; set; } = null!;

    [Display(Name = "Email address", Prompt = "Enter your email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;


    [Display(Name = "Service", Prompt = "Choose the service you are interested in")]
    [DataType(DataType.Text)]
    public string Service { get; set; } = null!;
    
    [Display(Name = "Message", Prompt = "Enter your message here")]
    [DataType(DataType.Text)]
    public string Message { get; set; } = null!;
}
