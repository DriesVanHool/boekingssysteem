using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Models;
using System.Collections.Generic;

namespace Boekingssysteem.ViewModels
{
    public class GebruikerOverviewViewModel
    {
        public List<CustomUser> Gebruikers { get; set; }
        public string Zoekterm { get; set; } 
    }
}
