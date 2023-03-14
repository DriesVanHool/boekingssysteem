using Microsoft.AspNetCore.Mvc;

namespace Boekingssysteem.Controllers
{
    public class AdminController: Controller
    {
        public IActionResult Docenten()
        {
            return View();
        }
        public IActionResult Richtingen()
        {
            return View();
        }
    }
}
