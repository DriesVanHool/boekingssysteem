using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.Models
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int RolId { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}
