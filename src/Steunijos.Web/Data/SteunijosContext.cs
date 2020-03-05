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
        }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<PaperAuthor> Authors { get; set; }

        public DbSet<PaperPayment> Payments { get; set; }

        public DbSet<Editor> Editors { get; set; }

        public DbSet<Paper> Papers { get; set; }

        public DbSet<JournalContent> JournalContents { get; set; }

        public DbSet<ApplicationRole> SteRoles { get; set; }




    }
}
