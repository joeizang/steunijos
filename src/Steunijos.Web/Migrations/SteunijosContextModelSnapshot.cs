﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Steunijos.Web.Data;

namespace Steunijos.Web.Migrations
{
    [DbContext(typeof(SteunijosContext))]
    partial class SteunijosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Steunijos.Web.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AffiliatedSchool")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDepartmentMember")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsHOD")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.Property<string>("OtherNames")
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProfilePhoto")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("SpecialtyField")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("Steunijos.Web.Models.AuthorsPapers", b =>
                {
                    b.Property<string>("PaperAuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaperId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("PaperAuthorId", "PaperId");

                    b.HasIndex("PaperId");

                    b.ToTable("AuthorsPapers");
                });

            modelBuilder.Entity("Steunijos.Web.Models.Journal", b =>
                {
                    b.Property<string>("IssnNo")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CopyrightYear")
                        .HasColumnType("TEXT");

                    b.Property<string>("VolumeName")
                        .HasColumnType("TEXT");

                    b.HasKey("IssnNo");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("Steunijos.Web.Models.JournalContent", b =>
                {
                    b.Property<string>("JournalContentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentTitle")
                        .HasColumnType("TEXT");

                    b.Property<string>("JournalIssnNo")
                        .HasColumnType("TEXT");

                    b.Property<int>("JournalPosition")
                        .HasColumnType("INTEGER");

                    b.HasKey("JournalContentId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("JournalIssnNo");

                    b.ToTable("JournalContents");
                });

            modelBuilder.Entity("Steunijos.Web.Models.Paper", b =>
                {
                    b.Property<string>("PaperId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ActualPath")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("JournalId")
                        .HasColumnType("TEXT");

                    b.Property<int>("NumberOfPages")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaperAbstract")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaperOriginalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaperTopic")
                        .HasColumnType("TEXT");

                    b.Property<string>("SavedPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectAreaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThumbnailPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("PaperId");

                    b.HasIndex("JournalId");

                    b.HasIndex("SubjectAreaId");

                    b.ToTable("Papers");
                });

            modelBuilder.Entity("Steunijos.Web.Models.PaperPayment", b =>
                {
                    b.Property<string>("PaperPaymentId")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("AmountPaid")
                        .HasColumnType("TEXT");

                    b.Property<string>("AuthorName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaperAuthorId")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TellerNumber")
                        .HasColumnType("TEXT");

                    b.HasKey("PaperPaymentId");

                    b.HasIndex("PaperAuthorId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Steunijos.Web.Models.SubjectArea", b =>
                {
                    b.Property<string>("SubjectAreaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubjectAreaName")
                        .HasColumnType("TEXT");

                    b.HasKey("SubjectAreaId");

                    b.ToTable("SubjectArea");
                });

            modelBuilder.Entity("Steunijos.Web.Models.ApplicationRole", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityRole");

                    b.HasDiscriminator().HasValue("ApplicationRole");
                });

            modelBuilder.Entity("Steunijos.Web.Models.Editor", b =>
                {
                    b.HasBaseType("Steunijos.Web.Models.ApplicationUser");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .HasColumnType("TEXT");

                    b.Property<string>("FacultyName")
                        .HasColumnType("TEXT");

                    b.Property<string>("JournalIssnNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("UniversityName")
                        .HasColumnType("TEXT");

                    b.HasIndex("JournalIssnNo");

                    b.HasDiscriminator().HasValue("Editor");
                });

            modelBuilder.Entity("Steunijos.Web.Models.PaperAuthor", b =>
                {
                    b.HasBaseType("Steunijos.Web.Models.ApplicationUser");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DepartmentName")
                        .HasColumnName("PaperAuthor_DepartmentName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Designation")
                        .HasColumnName("PaperAuthor_Designation")
                        .HasColumnType("TEXT");

                    b.Property<string>("FacultyName")
                        .HasColumnName("PaperAuthor_FacultyName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsValidAuthor")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UniversityName")
                        .HasColumnName("PaperAuthor_UniversityName")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("PaperAuthor");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Steunijos.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Steunijos.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Steunijos.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Steunijos.Web.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Steunijos.Web.Models.AuthorsPapers", b =>
                {
                    b.HasOne("Steunijos.Web.Models.PaperAuthor", "PaperAuthor")
                        .WithMany("Papers")
                        .HasForeignKey("PaperAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Steunijos.Web.Models.Paper", "Paper")
                        .WithMany("Authors")
                        .HasForeignKey("PaperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Steunijos.Web.Models.JournalContent", b =>
                {
                    b.HasOne("Steunijos.Web.Models.PaperAuthor", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("Steunijos.Web.Models.Journal", "Journal")
                        .WithMany("TableOfContents")
                        .HasForeignKey("JournalIssnNo");
                });

            modelBuilder.Entity("Steunijos.Web.Models.Paper", b =>
                {
                    b.HasOne("Steunijos.Web.Models.Journal", "Journal")
                        .WithMany("Papers")
                        .HasForeignKey("JournalId");

                    b.HasOne("Steunijos.Web.Models.SubjectArea", "SubjectArea")
                        .WithMany("Papers")
                        .HasForeignKey("SubjectAreaId");
                });

            modelBuilder.Entity("Steunijos.Web.Models.PaperPayment", b =>
                {
                    b.HasOne("Steunijos.Web.Models.PaperAuthor", null)
                        .WithMany("Payments")
                        .HasForeignKey("PaperAuthorId");
                });

            modelBuilder.Entity("Steunijos.Web.Models.Editor", b =>
                {
                    b.HasOne("Steunijos.Web.Models.Journal", null)
                        .WithMany("Editors")
                        .HasForeignKey("JournalIssnNo");
                });
#pragma warning restore 612, 618
        }
    }
}
