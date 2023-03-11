using Boekingssysteem.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Boekingssysteem.Data
{
    public class BoekingssysteemContext : DbContext
    {
        public BoekingssysteemContext(DbContextOptions<BoekingssysteemContext>options):base(options)
        {
        }

        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Afwezigheid> Afwezigheden { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Richting> Richtingen { get; set; }
        public DbSet<DocentRichting> DocentenRichtingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BS");
        }
    }
}
