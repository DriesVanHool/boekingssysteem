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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;

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
                Docenten = (List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent"),
                Richtingen = _context.Richtingen.ToList()
            };

            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel vm)
        {
            List<CustomUser> gebruikers =(List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent");
            vm.Richtingen = _context.Richtingen.Include(r=>r.DocentRichtingen).ToList();
            if (string.IsNullOrEmpty(vm.Zoekterm))
            {
                vm.Docenten = gebruikers;
            }
            else
            {
                vm.Docenten = gebruikers.Where(g => g.Voornaam.ToLower().Contains(vm.Zoekterm.ToLower()) || g.Achternaam.ToLower().Contains(vm.Zoekterm.ToLower())).ToList();
            }

            if (vm.RichtingId > 0)
            {
                vm.Docenten = vm.Docenten.Where(d => d.DocentRichtingen != null
                && d.DocentRichtingen.Any(dr => dr.RichtingId == vm.RichtingId)).ToList();
            }

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
