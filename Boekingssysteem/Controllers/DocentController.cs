using Microsoft.AspNetCore.Mvc;

namespace Boekingssysteem.Controllers
{
    public class DocentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
