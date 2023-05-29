using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boekingssysteem.ViewModels
{
    public class DocentStatusViewModel : IValidatableObject
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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (DateTime.Compare(BeginDatum, EindDatum) > 0)
            {
                errors.Add(new ValidationResult("Einddatum moet na de begindatum liggen.", new[] { nameof(EindDatum) }));
            }

            if (DateTime.Compare(BeginDatum, DateTime.Now.Date) < 0)
            {
                errors.Add(new ValidationResult("Begindatum kan niet in het verleden liggen", new[] { nameof(BeginDatum) }));
            }

            return errors;
        }
    }
}
