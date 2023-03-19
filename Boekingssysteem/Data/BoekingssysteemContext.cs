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

            modelBuilder.Entity<DocentRichting>()
                 .HasOne(d => d.Gebruiker)
                 .WithMany(x => x.DocentRichtingen)
                 .HasForeignKey(r => r.Rnummer)
                 .IsRequired();

            modelBuilder.Entity<DocentRichting>()
                 .HasOne(d => d.Richting)
                 .WithMany(x => x.DocentRichtingen)
                 .HasForeignKey(r => r.RichtingId)
                 .IsRequired();

            modelBuilder.Entity<Gebruiker>()
                 .HasOne(d => d.Rol)
                 .WithMany(x => x.Gebruikers)
                 .HasForeignKey(r => r.RolId)
                 .IsRequired();

            modelBuilder.Entity<Afwezigheid>()
                 .HasOne(d => d.Gebruiker)
                 .WithMany(x => x.Afwezigheden)
                 .HasForeignKey(r => r.Rnummer)
                 .IsRequired();
        }
    }
}
