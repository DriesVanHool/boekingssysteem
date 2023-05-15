using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Data;
using Boekingssysteem.Models;
using Boekingssysteem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Boekingssysteem.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController: Controller
    {
        private readonly BoekingssysteemContext _context;

        private readonly UserManager<CustomUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(BoekingssysteemContext context, UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Docenten()
        {
            GebruikerOverviewViewModel vm = new GebruikerOverviewViewModel()
            {
                Gebruikers = (List<CustomUser>) await _userManager.GetUsersInRoleAsync("docent")
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> DocentenStatussen()
        {
            DocentenStatussenViewModel vm = new DocentenStatussenViewModel()
            {

                Docenten = (List<CustomUser>) await _userManager.GetUsersInRoleAsync("docent")
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DocentenStatussen(string id, DocentenStatussenViewModel vm)
        {
           if (id != vm.Rnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CustomUser docent = _userManager.Users.First(x => x.Rnummer == id);
                    docent.Status = vm.Status;
                    await _userManager.UpdateAsync(docent);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_userManager.Users.Any(g => g.Rnummer == vm.Rnummer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToAction(nameof(DocentenStatussen));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToevoegenDocent(ToevoegenDocentViewModel vm) 
        {
            if (!string.IsNullOrEmpty(vm.Rnummer) &&  _userManager.Users.Where(g => g.Rnummer.ToLower() == vm.Rnummer.ToLower()).Count() > 0)
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
                    if (!_userManager.Users.Any(g => g.Rnummer == vm.Rnummer))
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
        public async Task<IActionResult> BewerkDocent(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            CustomUser docent = await _userManager.Users.FirstAsync(d => d.Rnummer == id);

            if (docent == null)
                return NotFound();

            BewerkDocentViewModel vm = new BewerkDocentViewModel()
            {
                Rnummer = docent.Rnummer,
                Voornaam = docent.Voornaam,
                Achternaam = docent.Achternaam,
                Email = docent.Email
            };

            return View(vm);
        }

        [HttpPost, ActionName("DeleteDocent")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerwijderDocentConfirm(string id)
        {
            CustomUser docent = await _userManager.FindByIdAsync(id);
            IdentityResult result = await _userManager.DeleteAsync(docent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Docenten));
        }


        public IActionResult Richtingen()
        {
            return View();
        }

        public IActionResult GrantPermissions()
        {
            GrantPermissionsViewModel viewModel = new GrantPermissionsViewModel()
            {
                Gebruikers = new SelectList(_userManager.Users.ToList(), "Id", "UserName"),
                Rollen = new SelectList(_roleManager.Roles.ToList(), "Id", "Name")
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GrantPermissions(GrantPermissionsViewModel gpv)
        {
            if (ModelState.IsValid)
            {
                CustomUser gb = await _userManager.FindByIdAsync(gpv.GebruikerId);
                IdentityRole role = await _roleManager.FindByIdAsync(gpv.RolId);
                if (gb != null && role != null)
                {
                    IdentityResult res = await _userManager.AddToRoleAsync(gb, role.Name);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Docenten");
                    }
                    else
                    {
                        foreach (IdentityError error in res.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Oei");
                }
            }
            return View(gpv);
        }
    }
}
