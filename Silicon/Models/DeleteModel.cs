using Silicon.Filters;
using System.ComponentModel.DataAnnotations;

namespace Silicon.models;


public class DeleteModel
{
    [CheckboxRequired]
    [Display(Name = "Yes, I want to delete my account.", Prompt = "I accept the terms and conditions")]
    public bool DeleteAccount { get; set; }

}

