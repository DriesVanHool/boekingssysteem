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
    public class AdminController : Controller
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
                Gebruikers = (List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent")
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Docenten(GebruikerOverviewViewModel vm)
        {
            List<CustomUser> gebruikers = (List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent");
            if (string.IsNullOrEmpty(vm.Zoekterm))
            {
                vm.Gebruikers = gebruikers;
            }
            else
            {
                vm.Gebruikers = gebruikers.Where(g => g.Voornaam.ToLower().Contains(vm.Zoekterm.ToLower()) || g.Achternaam.ToLower().Contains(vm.Zoekterm.ToLower())).ToList();
            }

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

        [HttpPost, ActionName("StatussenFilteren")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DocentenStatussen(DocentenStatussenViewModel vm)
        {
            List<CustomUser> gebruikers = (List<CustomUser>)await _userManager.GetUsersInRoleAsync("docent");
            if (string.IsNullOrEmpty(vm.Zoekterm))
            {
                vm.Docenten = gebruikers;
            }
            else
            {
                vm.Docenten = gebruikers.Where(g => g.Voornaam.ToLower().Contains(vm.Zoekterm.ToLower()) || g.Achternaam.ToLower().Contains(vm.Zoekterm.ToLower())).ToList();
            }

            return View(nameof(DocentenStatussen), vm);

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
        public async Task<IActionResult> BewerkDocent(string id, BewerkDocentViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    CustomUser docent = _context.CustomUsers.First(d => d.Id == id);
                    docent.Voornaam = vm.Voornaam;
                    docent.Achternaam = vm.Achternaam;
                    docent.Email = vm.Email;

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

            CustomUser docent = await _userManager.FindByIdAsync(id);

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


        [HttpPost, ActionName("DeleteLink")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerwijderLinkConfirm(int id)
        {
            DocentRichting link = _context.DocentenRichtingen.Include(l=>l.CustomUser).Where(l => l.DocentRichtingId == id).FirstOrDefault();
            string rNummer = link.CustomUser.Rnummer;
            _context.DocentenRichtingen.Remove(link);
            await _context.SaveChangesAsync();

            return RedirectToAction("LinkDocent", new { id = rNummer });
        }


        public IActionResult Richtingen()
        {
            RichtingenViewModel viewModel = new RichtingenViewModel()
            {
                Richtingen = _context.Richtingen.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToevoegenRichting(ToevoegenRichtingViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(new Richting()
                {
                    Naam = viewModel.Naam
                });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Richtingen));
            }
            return View(viewModel);
        }

        [HttpPost, ActionName("DeleteRichting")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerwijderRichtingConfirm(int id)
        {
            Richting richting = _context.Richtingen.Where(r => r.RichtingId == id).FirstOrDefault();
            _context.Richtingen.Remove(richting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Richtingen));
        }

        [HttpGet]
        public async Task<IActionResult> LinkDocent(string id)
        {
            if (id == null)
                return NotFound();

            CustomUser docent = await _userManager.Users.Include(u=>u.DocentRichtingen).FirstAsync(d => d.Rnummer == id);

            if (docent == null)
                return NotFound();

            LinkDocentViewModel vm = new LinkDocentViewModel()
            {
                Rnummer = docent.Rnummer,
                Voornaam = docent.Voornaam,
                Achternaam= docent.Achternaam,
                DocentRichtingen = docent.DocentRichtingen,
                Richtingen = _context.Richtingen.ToList()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkDocent(string id, LinkDocentViewModel vm)
        {
            if (id != vm.Rnummer)
            {
                return NotFound();
            }

            CustomUser docent = await _userManager.Users.FirstAsync(d => d.Rnummer == id);
            Richting richting = _context.Richtingen.FirstOrDefault(r => r.RichtingId == vm.RichtingId);

            if (docent == null)
                return NotFound();

            if (richting == null)
                return NotFound();


            if (ModelState.IsValid)
            {
                _context.Add(new DocentRichting()
                {
                    CustomUser = docent,
                    Richting = richting
                });
                await _context.SaveChangesAsync();

                return RedirectToAction("LinkDocent", new { id = docent.Rnummer });
            }

            return View(vm);
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

        [HttpGet]
        public IActionResult ToevoegenRichting()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> BewerkRichting(int? id)
        {
            if (id==null)
                return NotFound();

            Richting richting = _context.Richtingen.Where(r => r.RichtingId == id).FirstOrDefault();

            if (richting == null)
                return NotFound();

            BewerkRichtingViewModel vm = new BewerkRichtingViewModel()
            {
                RichtingId = richting.RichtingId,
                Naam = richting.Naam
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BewerkRichting(int id, BewerkRichtingViewModel viewModel)
        {
            if (id != viewModel.RichtingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Richting richting = new Richting()
                    {
                        RichtingId = viewModel.RichtingId,
                        Naam = viewModel.Naam
                    };
                    _context.Update(richting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException e)
                {
                    if (!_context.Richtingen.Any(r => r.RichtingId == viewModel.RichtingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Richtingen));
            }
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
