using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Silicon;

public class CourseController : Controller
{
    [Route("/Course")]
        public IActionResult Courses()
        {
            return View();
        }
}
