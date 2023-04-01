using Boekingssysteem.Data;
using Boekingssysteem.Models;
using Boekingssysteem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Boekingssysteem.Controllers
{
    public class AdminController: Controller
    {
        private readonly BoekingssysteemContext _context;
        public AdminController(BoekingssysteemContext context)
        {
            _context = context;
        }

        public IActionResult Docenten()
        {
            GebruikerOverviewViewModel vm = new GebruikerOverviewViewModel()
            {
                Gebruikers = _context.Gebruikers.Where(g => g.Rol.Naam.ToLower() == "docent").ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult DocentenStatussen()
        {
            DocentenStatussenViewModel vm = new DocentenStatussenViewModel()
            {
                Docenten = _context.Gebruikers.Where(g => g.Rol.Naam.ToLower() == "docent").ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DocentenStatussen(string id, DocentenStatussenViewModel vm)
        {
           if (id != vm.Rnummer)
            {
                //return NotFound();
            }

            try
            {
                Gebruiker docent = new Gebruiker()
                {
                    Rnummer = vm.Rnummer,
                    Voornaam = vm.Voornaam,
                    Achternaam = vm.Achternaam,
                    Email = vm.Email,
                    RolId = vm.RolId,
                    Status = vm.Status,
                };
                _context.Update(docent);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!_context.Gebruikers.Any(g => g.Rnummer == vm.Rnummer))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(DocentenStatussen));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToevoegenDocent(ToevoegenDocentViewModel vm) 
        {
            if (!string.IsNullOrEmpty(vm.Rnummer) &&  _context.Gebruikers.Where(g => g.Rnummer.ToLower() == vm.Rnummer.ToLower()).Count() > 0)
            {
                ModelState.AddModelError("Rnummer", "Rnummer bestaat al");
            }
            if (ModelState.IsValid)
            {
                _context.Add(new Gebruiker()
                {
                    Rnummer= vm.Rnummer,
                    Voornaam = vm.Voornaam,
                    Achternaam = vm.Achternaam,
                    Email= vm.Email,
                    RolId= 2,
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Docenten));
            }

            return View(vm);
        }


        [HttpGet]
        public IActionResult ToevoegenDocent()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BewerkDocent(string id, BewerkDocentViewModel vm)
        {
            if (id != vm.Rnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Gebruiker docent = new Gebruiker()
                    {
                        Rnummer= vm.Rnummer,
                        Voornaam = vm.Voornaam,
                        Achternaam = vm.Achternaam,
                        Email = vm.Email,
                        RolId = vm.RolId,
                        Status = vm.Status,
                    };
                    _context.Update(docent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Gebruikers.Any(g => g.Rnummer == vm.Rnummer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Docenten));
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult BewerkDocent(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            Gebruiker docent = _context.Gebruikers.FirstOrDefault(d => d.Rnummer == id);

            if (docent == null)
                return NotFound();

            BewerkDocentViewModel vm = new BewerkDocentViewModel()
            {
                Rnummer = docent.Rnummer,
                Voornaam = docent.Voornaam,
                Achternaam = docent.Achternaam,
                Email = docent.Email,
                RolId = docent.RolId,
            };

            return View(vm);
        }

        [HttpPost, ActionName("DeleteDocent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerwijderDocentConfirm(string id)
        {
            Gebruiker docent = await _context.Gebruikers.FindAsync(id);
            _context.Gebruikers.Remove(docent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Docenten));
        }


        public IActionResult Richtingen()
        {
            return View();
        }
    }
}
