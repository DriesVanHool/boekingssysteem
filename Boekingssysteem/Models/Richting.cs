using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.Models
{
    [Table("Richting")]
    public class Richting
    {
        [Key]
        public int RichtingId { get; set; }
        [Required]
        public string Naam { get; set; }

        public ICollection<DocentRichting> DocentRichtingen { get; set; }
    }
}
