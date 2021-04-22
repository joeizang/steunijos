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

        public DbSet<Paper> Papers { get; set; }

        public DbSet<Editor> Editors { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<JournalContent> JournalContents { get; set; }

        public DbSet<PaperAuthor> PaperAuthors { get; set; }

        public DbSet<PaperPayment> PaperPayments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
