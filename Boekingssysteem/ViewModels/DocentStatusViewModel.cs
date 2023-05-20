using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Boekingssysteem.ViewModels
{
    public class DocentStatusViewModel
    {
        public List<Afwezigheid> Afwezigheden { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public string Opmerking { get; set; }
        public string DocentId { get; set; }
        public int AfwezigheidId { get; set; }
        public bool? Status { get; set; }

        public string GetStatus()
        {
            if (Status == null) { return "Onbekend"; }
            if (Status == true) { return "Aanwezig"; }
            return "Afwezig";
        }

        public string GetButtonColor()
        {
            if (Status == null) { return "btn-warning"; }
            if (Status == true) { return "btn-success"; }
            return "btn-danger";
        }
    }
}
