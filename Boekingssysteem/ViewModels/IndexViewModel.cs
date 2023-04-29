using System.Collections.Generic;
using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Models;

namespace Boekingssysteem.ViewModels
{
    public class IndexViewModel
    {
        public List<CustomUser> Docenten { get; set; }
    }
}
