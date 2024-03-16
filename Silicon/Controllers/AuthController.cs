using Microsoft.AspNetCore.Mvc;
using Silicon.Models;

namespace Silicon.Controllers
{
    public class AuthController : Controller
    {
        #region SignIn
        [HttpGet]
        [Route("/SignIn")]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [Route("/SignIn")]
        public IActionResult SignIn(SignInViewModel viewModel)
        { 
            if (ModelState.IsValid)
            {

            }                   
            return View(); }
        #endregion

        #region SignUp
        [HttpGet]
        [Route("/signup")]
        public IActionResult SignUp ()
        {
            return View();
        }

        [HttpPost]
        [Route("/signup")]
        public IActionResult SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            }
            return View(viewModel);
        }
        #endregion
    }
}
