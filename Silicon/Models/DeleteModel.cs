using Silicon.Filters;
using System.ComponentModel.DataAnnotations;

namespace Silicon.models;


public class DeleteModel
{
    [CheckboxRequired]
    [Display(Name = "I agree to the Terms & .", Prompt = "I accept the terms and conditions")]
    public bool DeleteAccount { get; set; }

}

