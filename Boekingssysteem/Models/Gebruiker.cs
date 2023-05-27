using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.Models
{
    [Table("Gebruiker")]
    public class Gebruiker
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

        [ForeignKey("RolId")]
        public Rol Rol { get; set; }

    }
}
