using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    public class DefaultController(SignInManager<UserEntity> signInManager) : Controller
    {
        private readonly SignInManager<UserEntity> _signInManager = signInManager;

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult NotAvailable()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
