using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Data;
using Boekingssysteem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System;
using Boekingssysteem.Models;

namespace Boekingssysteem.Controllers
{
    [Authorize]
    public class DocentController : Controller
    {
        private readonly BoekingssysteemContext _context;

        private readonly UserManager<CustomUser> _userManager;

        public DocentController(BoekingssysteemContext context, UserManager<CustomUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            CustomUser docent = await _userManager.FindByEmailAsync(User.Identity.Name);

            DocentStatusViewModel viewModel = new DocentStatusViewModel();
            viewModel.Status = docent.Status;
            viewModel.BeginDatum = DateTime.Now;
            viewModel.EindDatum = DateTime.Now;
            viewModel.AfwezigheidId = -1;
            viewModel.DocentId = docent.Id;
            viewModel.Afwezigheden = _context.Afwezigheden.Where(a => a.Rnummer == docent.Id).ToList();

            return View(viewModel);
        }

        public async Task<IActionResult> StatusWijzigen()
        {
            CustomUser docent = await _userManager.FindByEmailAsync(User.Identity.Name);

            if (docent == null) { return NotFound(); }

            if (docent.Status == null) 
            {
                docent.Status = true; 
            } 
            else
            {
                docent.Status = !docent.Status;
            }

            _context.Update(docent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Afwezigheden(DocentStatusViewModel vm)
        {
            CustomUser docent = await _userManager.FindByEmailAsync(User.Identity.Name);

            try
            {
                Afwezigheid afwezigheid;

                if (vm.AfwezigheidId < 0)
                    afwezigheid = new Afwezigheid();
                else
                    afwezigheid = _context.Afwezigheden.First(a => a.AfwezigheidId == vm.AfwezigheidId);

                afwezigheid.Rnummer = vm.DocentId;
                afwezigheid.Begindatum = vm.BeginDatum;
                afwezigheid.Einddatum = vm.EindDatum;
                afwezigheid.Opmerking = vm.Opmerking;

                if (vm.AfwezigheidId < 0)
                    _context.Afwezigheden.Add(afwezigheid);
                else
                    _context.Afwezigheden.Update(afwezigheid);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
