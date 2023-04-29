using Boekingssysteem.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.Areas.Identity.Data
{
    public class CustomUser: IdentityUser
    {
        [PersonalData]
        public string Rnummer { get; set; }
        [PersonalData]
        public string Voornaam { get; set; }
        [PersonalData]
        public string Achternaam { get; set; }

        [PersonalData]
        public bool? Status { get; set; }
        public ICollection<DocentRichting> DocentRichtingen { get; set; }

        public ICollection<Afwezigheid> Afwezigheden { get; set; }
    }
}
