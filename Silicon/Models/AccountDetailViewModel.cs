using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class AccountDetailViewModel
    {
        public UserDetailModel? UserDetail { get; set; }
        public AddressDetailModel? AddressDetail { get; set; }  
    }
}
