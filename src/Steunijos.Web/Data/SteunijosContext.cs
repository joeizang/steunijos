using Steunijos.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Steunijos.Web.Data
{
    public class SteunijosContext : IdentityDbContext<ApplicationUser>
    {
        public SteunijosContext(DbContextOptions<SteunijosContext> options) :
            base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PaperAuthor>()
                .HasMany(a => a.Payments);
            builder.Entity<ContactUsSubmission>()
                .HasKey(c => c.SubmissionId);

            builder.Entity<ApplicationRole>(entity => entity.Property(x => x.NormalizedName).HasMaxLength(256));
            builder.Entity<ApplicationRole>(entity => entity.Property(x => x.Name).HasMaxLength(256));
            builder.Entity<ApplicationRole>(entity => entity.Property(x => x.Id).HasMaxLength(200));

            builder.Entity<Journal>()
                .HasOne(x => x.TableOfContents)
                .WithOne(j => j.Journal)
                .HasForeignKey<JournalContent>(f => f.JournalId);
            builder.Entity<Journal>()
                .HasIndex(j => j.IssnNo);
            builder.Entity<Journal>()
                .HasIndex(j => j.JournalId);
            builder.Entity<Journal>()
                .HasIndex(j => j.VolumeName);


        }

        public DbSet<ContactUsSubmission> ContactUsSubmissions { get; set; }
        public DbSet<Journal> Journals { get; set; }

        public DbSet<PaperAuthor> Authors { get; set; }

        public DbSet<PaperPayment> Payments { get; set; }

        public DbSet<Editor> Editors { get; set; }

        public DbSet<Paper> Papers { get; set; }

        public DbSet<JournalContent> JournalContents { get; set; }

        public DbSet<ApplicationRole> SteRoles { get; set; }




    }
}
