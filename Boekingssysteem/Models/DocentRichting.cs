using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.Models
{
    [Table("DocentRichting")]
    public class DocentRichting
    {
        [Key]
        public int DocentRichtingId { get; set; }


        [Required]
        public string Rnummer { get; set; }

        [Required]
        public int RichtingId { get; set; }

        [ForeignKey("Rnummer")]
        public Gebruiker Gebruiker { get; set; }

        [ForeignKey("RichtingId")]
        public Richting Richting { get; set; }

    }
}
