using Microsoft.AspNetCore.Mvc;

namespace Silicon.Controllers
{
    public class DefaultController : Controller
    {
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
