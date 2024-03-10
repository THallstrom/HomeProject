using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    public class Default : Controller
    {
        public IActionResult Home()
        {
            return View();
        }
    }
}
