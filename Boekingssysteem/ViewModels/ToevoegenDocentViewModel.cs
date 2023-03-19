using Boekingssysteem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class ToevoegenDocentViewModel
    {
        [Required]
        public string Rnummer { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int RolId { get; set; }
    }
}
