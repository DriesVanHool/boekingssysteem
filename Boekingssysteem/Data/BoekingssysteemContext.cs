using Boekingssysteem.Areas.Identity.Data;
using Boekingssysteem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Boekingssysteem.Data
{
    public class BoekingssysteemContext : IdentityDbContext<CustomUser>
    {
        public BoekingssysteemContext(DbContextOptions<BoekingssysteemContext>options):base(options)
        {
        }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Afwezigheid> Afwezigheden { get; set; }
        public DbSet<Rol> Rollen { get; set; }
        public DbSet<Richting> Richtingen { get; set; }
        public DbSet<DocentRichting> DocentenRichtingen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("BS");

            modelBuilder.Entity<DocentRichting>()
                 .HasOne(d => d.CustomUser)
                 .WithMany(x => x.DocentRichtingen)
                 .HasForeignKey(r => r.Rnummer)
                 .IsRequired();

            modelBuilder.Entity<DocentRichting>()
                 .HasOne(d => d.Richting)
                 .WithMany(x => x.DocentRichtingen)
                 .HasForeignKey(r => r.RichtingId)
                 .IsRequired();


            modelBuilder.Entity<Afwezigheid>()
                 .HasOne(d => d.CustomUser)
                 .WithMany(x => x.Afwezigheden)
                 .HasForeignKey(r => r.Rnummer)
                 .IsRequired();
        }
    }
}
