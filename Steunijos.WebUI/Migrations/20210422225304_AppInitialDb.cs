using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Steunijos.WebUI.Migrations
{
    public partial class AppInitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    DepartmentName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    FacultyName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    UniversityName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IssnNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    VolumeName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ActualPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    SavedPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CopyrightYear = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    JournalContentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaperAuthors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Designation = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    DepartmentName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    FacultyName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    UniversityName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    IsValidAuthor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperAuthors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(100)", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(100)", nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    SavedPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    PaperOriginalName = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    ActualPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    PaperTopic = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true),
                    JournalId = table.Column<int>(type: "int", maxLength: 150, nullable: false),
                    ThumbnailPath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Papers_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ContentTitle = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    PaperAuthorId = table.Column<int>(type: "int", nullable: false),
                    JournalPosition = table.Column<int>(type: "int", nullable: false),
                    JournalId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalContents_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalContents_PaperAuthors_PaperAuthorId",
                        column: x => x.PaperAuthorId,
                        principalTable: "PaperAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaperPayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TellerNumber = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    AuthorName = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    PaperAuthorId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperPayments_PaperAuthors_PaperAuthorId",
                        column: x => x.PaperAuthorId,
                        principalTable: "PaperAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorsPapers",
                columns: table => new
                {
                    PaperId = table.Column<int>(type: "int", nullable: false),
                    PaperAuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsPapers", x => new { x.PaperAuthorId, x.PaperId });
                    table.ForeignKey(
                        name: "FK_AuthorsPapers_PaperAuthors_PaperAuthorId",
                        column: x => x.PaperAuthorId,
                        principalTable: "PaperAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorsPapers_Papers_PaperId",
                        column: x => x.PaperId,
                        principalTable: "Papers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaperPaperAuthor",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    PapersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperPaperAuthor", x => new { x.AuthorsId, x.PapersId });
                    table.ForeignKey(
                        name: "FK_PaperPaperAuthor_PaperAuthors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "PaperAuthors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaperPaperAuthor_Papers_PapersId",
                        column: x => x.PapersId,
                        principalTable: "Papers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsPapers_PaperId",
                table: "AuthorsPapers",
                column: "PaperId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalContents_JournalId",
                table: "JournalContents",
                column: "JournalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JournalContents_PaperAuthorId",
                table: "JournalContents",
                column: "PaperAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperPaperAuthor_PapersId",
                table: "PaperPaperAuthor",
                column: "PapersId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperPayments_PaperAuthorId",
                table: "PaperPayments",
                column: "PaperAuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_JournalId",
                table: "Papers",
                column: "JournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuthorsPapers");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "JournalContents");

            migrationBuilder.DropTable(
                name: "PaperPaperAuthor");

            migrationBuilder.DropTable(
                name: "PaperPayments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "PaperAuthors");

            migrationBuilder.DropTable(
                name: "Journals");
        }
    }
}
