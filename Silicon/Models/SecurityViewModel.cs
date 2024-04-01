using Silicon.Models;
using System.ComponentModel.DataAnnotations;

namespace Silicon.models;

public class SecurityViewModel
{
    [Display(Name = "Current password", Prompt = "Enter your current password")]
    [DataType(DataType.Password)]
    public string CurrentPassword { get; set; } = null!;

    [Display(Name = "New password", Prompt = "Enter your new password")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = null!;


    [Display(Name = "Confirm new password", Prompt = "Confirm new password")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = null!;
}
