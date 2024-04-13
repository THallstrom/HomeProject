using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Silicon.models;
using Silicon.Models;

namespace Silicon.Controllers
{
    [Authorize]
    public class AccountController(DataContext dataContext, UserManager<UserEntity> userManager, AccountService accountService, SignInManager<UserEntity> signInManager) : Controller
    {
        private readonly DataContext _context = dataContext;
        private readonly UserManager<UserEntity> _userManager = userManager;
        private readonly AccountService _accountService = accountService;
        private readonly SignInManager<UserEntity> _signInManager = signInManager;

        #region AccountDetails
        public async Task<IActionResult> AccountDetails()
        {
            var user = await _userManager.GetUserAsync(User);
            var userAddress = _context.Addresses.FirstOrDefault(y => y.Id == user!.AddressId);
            var viewModel = new AccountDetailViewModel();

            if (user != null)
            {
                viewModel.UserDetail = new UserDetailModel();
                viewModel.UserDetail.FirstName = user.FirstName;
                viewModel.UserDetail.LastName = user.LastName;
                viewModel.UserDetail.Email = user.Email!;
                viewModel.UserDetail.Phone = user.PhoneNumber;

                if (userAddress != null)
                {
                    viewModel.AddressDetail = new AddressDetailModel();
                    viewModel.AddressDetail.Addressline1 = userAddress.Address1!;
                    viewModel.AddressDetail.Addressline2 = userAddress.Address2!;
                    viewModel.AddressDetail.PostalCode = userAddress.PostalCode!;
                    viewModel.AddressDetail.City = userAddress.City!;
                    return View(viewModel);
                }
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

        [HttpPost]
        public async Task<IActionResult> Security(SecurityViewModel security)
        {
            if (security.Password != null)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return NotFound();
                }
                if (security.Password.NewPassword == security.Password.ConfirmPassword)
                {

                    var changePasswordResult = await _userManager.ChangePasswordAsync(user, security.Password.CurrentPassword, security.Password.NewPassword);
                    if (!changePasswordResult.Succeeded)
                    {
                        ViewBag.ErrorMessage = "Password is not changed";
                        return View(security);
                    }
                    else
                    {
                        ViewBag.SuccessMessage = "Password is changed";
                        await _signInManager.RefreshSignInAsync(user);
                    }
                        
                    return View(security);
                }
                else
                {
                    ViewBag.ErrorMessage = "Password is incorrect";
                    return View(security);
                }

            }
            return View(security);
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
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (model != null && user != null)
                {
                    if (user.AddressId == null)
                    {
                        var Address = new AddressEntity
                        {
                            Address1 = model.AddressDetail.Addressline1,
                            Address2 = model.AddressDetail.Addressline2,
                            PostalCode = model.AddressDetail.PostalCode,
                            City = model.AddressDetail.City
                        };
                        _context.Addresses.Add(Address);
                        await _context.SaveChangesAsync();

                        user.Address = Address;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var address = _context.Addresses.FirstOrDefault(x => x.Id == user.AddressId);
                        if (address != null && model.AddressDetail.Addressline1 != null && model.AddressDetail.PostalCode != null && model.AddressDetail.City != null)
                        {

                            address.Address1 = model.AddressDetail.Addressline1;
                            address.Address2 = model.AddressDetail.Addressline2;
                            address.PostalCode = model.AddressDetail.PostalCode;
                            address.City = model.AddressDetail.City;

                            _context.Addresses.Update(address);
                            await _context.SaveChangesAsync();
                        }
                        return RedirectToAction("AccountDetails", "Account")!;

                    }
                    return null!;
                }

                return RedirectToAction("Home", "Default");
            }
            else return null!;
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
                    user.FirstName = form.UserDetail.FirstName;
                    user.LastName = form.UserDetail.LastName;
                    user.PhoneNumber = form.UserDetail.Phone;

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
        public IActionResult DeleteAccount()
        {
            return RedirectToAction("Home", "Default");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAccount(SecurityViewModel viewModel)
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
                    return RedirectToAction("NotAvailable", "Default");
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
