using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Boekingssysteem.Controllers
{
    [Authorize]
    public class DocentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
