using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Steunijos.Domain.DomainModels;

namespace Steunijos.WebUI.Data
{
    public class SteunijosContext : IdentityDbContext
    {
        public SteunijosContext(DbContextOptions<SteunijosContext> options)
            : base(options)
        {
        }

        public DbSet<ContactUsSubmission> ContactUsSubmissions { get; set; }
        public DbSet<Paper> Papers { get; set; }

        public DbSet<Editor> Editors { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<JournalContent> JournalContents { get; set; }

        public DbSet<PaperAuthor> PaperAuthors { get; set; }

        public DbSet<PaperPayment> PaperPayments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PaperAuthor>()
                .HasMany(a => a.Payments)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AuthorsPapers>()
                .HasOne(p => p.Paper)
                .WithMany(p => p.AuthorsPapers)
                .HasForeignKey(x => x.PaperId);
            builder.Entity<AuthorsPapers>()
                .HasOne(ap => ap.PaperAuthor)
                .WithMany(pa => pa.AuthorsPapers)
                .HasForeignKey(x => x.PaperAuthorId);
            builder.Entity<AuthorsPapers>()
                .HasKey(k => new {k.PaperAuthorId, k.PaperId});
                

            builder.Entity<Journal>()
                .HasOne(j => j.TableOfContents)
                .WithOne(j => j.Journal)
                .HasForeignKey<JournalContent>(j => j.JournalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Journal>()
                .HasMany(j => j.Papers)
                .WithOne(p => p.Journal)
                .HasForeignKey(x => x.JournalId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
