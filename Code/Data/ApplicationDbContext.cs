using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smstylers.Models;
using System;
using System.Collections.Generic;
using System.Text;
using smstylers.Controllers;

namespace smstylers.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Filiaal> Filialen { get; set; }

        public DbSet<Surfboards> Surfboards { get; set; }

        public DbSet<Voorraad> Voorraad{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Voorraad>()
                .HasKey(v => new { v.SurfboardId, v.FiliaalId });

            builder.Entity<Voorraad>().
                HasOne(v => v.Surfboards)
                .WithMany(s => s.Voorraad)
                .HasForeignKey(v => v.SurfboardId);
        }

        public DbSet<smstylers.Models.Materiaal> Materiaal { get; set; }

        public DbSet<smstylers.Models.Afspraak> Afspraak { get; set; }

        public DbSet<smstylers.Controllers.faq> faq { get; set; }
    }
}
