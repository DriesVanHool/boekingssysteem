using Boekingssysteem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class LinkDocentViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Rnummer { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        public ICollection<DocentRichting> DocentRichtingen { get;set; }
        public List<Richting> Richtingen { get; set; }
        public int RichtingId { get; set; }
    }
}
