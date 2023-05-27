using Boekingssysteem.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class DocentLinkenViewModel
    {
        public string GebruikerId { get; set; }

        public List<Richting> Richtingen { get; set; }
    }
}
