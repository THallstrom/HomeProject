using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class AddressDetailModel
    {
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
