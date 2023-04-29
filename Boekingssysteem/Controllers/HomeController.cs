using Boekingssysteem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Boekingssysteem.ViewModels;
using Boekingssysteem.Data;
using Microsoft.AspNetCore.Identity;
using Boekingssysteem.Areas.Identity.Data;

namespace Boekingssysteem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BoekingssysteemContext _context;
        private readonly UserManager<CustomUser> _userManager;
        public HomeController(ILogger<HomeController> logger, BoekingssysteemContext ctx, UserManager<CustomUser> userManager)
        {
            _logger = logger;
            _context = ctx;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IndexViewModel vm = new IndexViewModel()
            {
                Docenten = (List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent")
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
