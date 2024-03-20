using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    public class AccountController : Controller
    {
        [Route("/Account")]
        public IActionResult AccountDetails()
        {
            return View();
        }
    }
}
