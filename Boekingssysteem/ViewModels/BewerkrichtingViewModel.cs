using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class BewerkRichtingViewModel
    {

        [Required]
        public int RichtingId { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}
