using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class BewerkDocentViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Rnummer { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Status { get; set; }
    }
}
