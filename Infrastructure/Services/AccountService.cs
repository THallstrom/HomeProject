using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountService(UserManager<UserEntity> userManager, IConfiguration configuration, DataContext context)
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;
    private readonly DataContext _dataContext = context;

    public async Task<bool> UploadUserProfileImageAsync(ClaimsPrincipal userClaims, IFormFile file)
    {
        try
        {
            if (userClaims != null && file != null && file.Length != 0) 
            {
                var user = await _userManager.GetUserAsync(userClaims);
                if (user != null)
                {
                    var fileName = $"p_{user.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["Filepath:ProfileUploadPath"]!, fileName);

                    using var fs = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fs);

                    user.ProfilePicture = fileName;
                    _dataContext.SaveChanges();
                    await _dataContext.SaveChangesAsync();
                }
            }
        } catch (Exception ex) { }
        return false;
    }
}
