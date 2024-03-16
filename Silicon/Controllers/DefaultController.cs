using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
