using Microsoft.AspNetCore.Mvc;

namespace Boekingssysteem.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Reset()
        {
            return View();
        }
    }
}
