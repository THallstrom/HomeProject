using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public IActionResult AccountDetails()
        {
            return View();
        }
        [Route("/Security")]
        public IActionResult Security()
        {
            return View();
        }
    }
}
