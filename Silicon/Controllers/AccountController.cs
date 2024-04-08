using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Silicon.models;
using Silicon.Models;

namespace Silicon.Controllers
{
    [Authorize]
    public class AccountController(DataContext dataContext, UserManager<UserEntity> userManager, AccountService accountService) : Controller
    {
        private readonly DataContext _context = dataContext;
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly AccountService _accountService = accountService;

        #region AccountDetails
        public async Task<IActionResult> AccountDetails()
        {
            var user = await _userManager.GetUserAsync(User);
            // Den borde inte se ut som den gör, bör vara en await funktion eller kontroll
            var userAddress = _context.Addresses.FirstOrDefault(y => y.Id == user.AddressId);
            var viewModel = new AccountDetailViewModel();

            if (user != null)
            {
                if (userAddress != null)
                {
                    {
                        viewModel.FirstName = user.FirstName;
                        viewModel.LastName = user.LastName;
                        viewModel.Email = user.Email!;
                        viewModel.Phone = user.PhoneNumber;
                        viewModel.Addressline1 = userAddress.Address1!;
                        viewModel.Addressline2 = userAddress.Address2!;
                        viewModel.PostalCode = userAddress.PostalCode!;
                        viewModel.City = userAddress.City!;

                    };
                    return View(viewModel);
                }
                else
                {
                    viewModel.FirstName = user.FirstName;
                    viewModel.LastName = user.LastName;
                    viewModel.Email = user.Email!;
                    viewModel.Phone = user.PhoneNumber;
                };
                return View(viewModel);

            }
            return View();
        }
        #endregion

        #region Security
        public IActionResult Security()
        {
            
            return View();
            
            
        }
        #endregion

        #region SavedCourses
        public IActionResult SavedCourses()
        {

            return View();
        }
        #endregion

        #region UserDetails
        public IActionResult UserDetails()
        {
            var user = _userManager.Users;
            return View(user);
        }
        #endregion

        #region SaveAddress
        public async Task<IActionResult> SaveAddress(AccountDetailViewModel model)
        {
            //if (ModelState.IsValid)
            {

                var userEmail = User.Identity.Name;
                // Den här är bättre för att ta in informationen, radera den över
                var test = await _userManager.GetUserAsync(User);
                var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
                if (model != null && user != null)
                {
                    if (user.AddressId == null)
                    {
                        var Address = new AddressEntity
                        {
                            Address1 = model.Addressline1,
                            Address2 = model.Addressline2,
                            PostalCode = model.PostalCode,
                            City = model.City
                        };
                        _context.Addresses.Add(Address);
                        await _context.SaveChangesAsync();

                        user.Address = Address;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var address = _context.Addresses.FirstOrDefault(x => x.Id == user.AddressId);
                        if (address != null)
                        {
                            address.Address1 = model.Addressline1;
                            address.Address2 = model.Addressline2;
                            address.PostalCode = model.PostalCode;
                            address.City = model.City;

                            await _context.SaveChangesAsync();
                        }
                        return null!;

                    }
                    return null!;
                }

                return RedirectToAction("Home", "Default");
            }
            //else return null!;
        }
        #endregion

        #region UserProfile
        public async Task<IActionResult> UserProfile(AccountDetailViewModel form)
        {
            if (ModelState.IsValid)
            {
                var userEmail = User.Identity.Name;
                var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
                if (user != null)
                {
                    user.FirstName = form.FirstName;
                    user.LastName = form.LastName;
                    user.PhoneNumber = form.Phone;

                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Home", "Default");
        }
        #endregion

        #region ImageUploader
        [HttpPost]
        public async Task<IActionResult> ImageUploader(IFormFile file)
        {
            var result = await _accountService.UploadUserProfileImageAsync(User, file);
            return RedirectToAction("AccountDetails", "Account");
        }
        #endregion

        #region DeleteAccount
        [HttpGet]
        public IActionResult DeleteAccount ()
        {
            return RedirectToAction("Home", "Default");
        }

        [HttpPost]
        public async Task  <IActionResult> DeleteAccount (SecurityViewModel viewModel)
        {
            if (viewModel.Delete != null)
            {
                if (viewModel.Delete.DeleteAccount == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    _context.Users.Remove(user!);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Home", "Default");
                }
                else
                {
                    return null!;
                }
            } 
            else
            {               
                return RedirectToAction("Security", "Account");
            }
        }
        #endregion
    }
}
