﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boekingssysteem.Models
{
    [Table("Afwezigheid")]
    public class Afwezigheid
    {
        [Key]
        public int AfwezigheidId { get; set; }
        [Required]
        public DateTime Begindatum { get; set; }
        [Required]
        public DateTime Einddatum { get; set; }
        public string Opmerking { get; set; }

        [Required]
        public int Rnummer { get; set; }

        [ForeignKey("Rnummer")]
        public Gebruiker Gebruiker { get; set; }
    }
}