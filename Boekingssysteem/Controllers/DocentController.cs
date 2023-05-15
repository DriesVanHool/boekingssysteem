using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Data;
using Boekingssysteem.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
            DocentStatusViewModel viewModel = new DocentStatusViewModel()
            {
                Status = docent.Status
            };

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
    }
}
