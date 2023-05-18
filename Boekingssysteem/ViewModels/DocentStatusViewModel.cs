﻿namespace Boekingssysteem.ViewModels
{
    public class DocentStatusViewModel
    {
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
