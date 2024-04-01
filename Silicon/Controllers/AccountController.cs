using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon.models;
using Silicon.Models;

namespace Silicon.Controllers
{
    [Authorize]
    public class AccountController(DataContext dataContext) : Controller
    {
        public readonly DataContext _context = dataContext;

        #region AccountDetails
        public async Task<IActionResult> AccountDetails()
        {
            var userEmail = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == userEmail);
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
        [Route("/Security")]
        public IActionResult Security(SecurityViewModel viewModel)
        {
            return View(viewModel);
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
            var viewModel = new UserDetailModel
            {
                FirstName = "Thomas",
                LastName = "Hallström",
                Email = "Minimoto@hotmail.com"
            };
            return View(viewModel);
        }
        #endregion

        #region SaveAddress
        public async Task<IActionResult> SaveAddress(AccountDetailViewModel model)
        {
            var userEmail = User.Identity.Name;
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

                }
            }

            return RedirectToAction("Home", "Default");
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
    }
}
