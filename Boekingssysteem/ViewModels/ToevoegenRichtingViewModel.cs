using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class ToevoegenRichtingViewModel
    {
        [Required]
        public string Naam { get; set; }
    }
}
