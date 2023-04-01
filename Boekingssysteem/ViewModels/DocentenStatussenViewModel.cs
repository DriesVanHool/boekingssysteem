using System.Collections.Generic;
using Boekingssysteem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.ViewModels
{
    public class DocentenStatussenViewModel
    {
        [Key]
        public string Rnummer { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Achternaam { get; set; }
        [Required]
        public string Email { get; set; }
        public bool? Status { get; set; }
        [Required]
        public int RolId { get; set; }

        public List<Gebruiker> Docenten { get; set; }
    }
}