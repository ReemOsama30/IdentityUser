using Microsoft.AspNetCore.Mvc;

namespace user_Identity.Controllers
{
    public class Users : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoogleLogIn()
        {
            return View();
        }
    }
}
