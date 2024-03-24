using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult AccountDetails()
        {
            var userEmail = User.Identity.Name;
            ViewData["userEmail"] = userEmail;
            return View();
        }
        [Route("/Security")]
        public IActionResult Security()
        {
            return View();
        }
        public IActionResult SavedCourses()
        {
            return View();
        }
    }
}
