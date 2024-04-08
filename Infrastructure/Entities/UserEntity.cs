using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Identity.Client;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;
    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;
    public string ProfilePicture { get; set; } = "incognito.jpg";
    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}
