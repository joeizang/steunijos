using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Steunijos.Web.Migrations
{
    public partial class InitialAppData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    OtherNames = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    AffiliatedSchool = table.Column<string>(nullable: true),
                    IsDepartmentMember = table.Column<bool>(nullable: false),
                    IsHOD = table.Column<bool>(nullable: false),
                    SpecialtyField = table.Column<string>(nullable: true),
                    ProfilePhoto = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Designation = table.Column<string>(nullable: true),
                    DepartmentName = table.Column<string>(nullable: true),
                    FacultyName = table.Column<string>(nullable: true),
                    UniversityName = table.Column<string>(nullable: true),
                    PaperAuthor_Designation = table.Column<string>(maxLength: 20, nullable: true),
                    PaperAuthor_DepartmentName = table.Column<string>(maxLength: 150, nullable: true),
                    PaperAuthor_FacultyName = table.Column<string>(maxLength: 150, nullable: true),
                    PaperAuthor_UniversityName = table.Column<string>(maxLength: 150, nullable: true),
                    IsValidAuthor = table.Column<bool>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsSubmissions",
                columns: table => new
                {
                    SubmissionId = table.Column<string>(nullable: false),
                    SendersFullName = table.Column<string>(nullable: true),
                    ReceivingEmailAddress = table.Column<string>(nullable: true),
                    SubmissionDate = table.Column<DateTimeOffset>(nullable: false),
                    SendersEmail = table.Column<string>(nullable: true),
                    MessageSent = table.Column<string>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    MessageSubject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsSubmissions", x => x.SubmissionId);
                });

            migrationBuilder.CreateTable(
                name: "Journals",
                columns: table => new
                {
                    JournalId = table.Column<string>(maxLength: 150, nullable: false),
                    IssnNo = table.Column<string>(maxLength: 20, nullable: true),
                    VolumeName = table.Column<string>(maxLength: 50, nullable: true),
                    ActualPath = table.Column<string>(maxLength: 300, nullable: true),
                    SavedPath = table.Column<string>(maxLength: 300, nullable: true),
                    CopyrightYear = table.Column<DateTimeOffset>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    JournalContentId = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journals", x => x.JournalId);
                });

            migrationBuilder.CreateTable(
                name: "SubjectArea",
                columns: table => new
                {
                    SubjectAreaId = table.Column<string>(nullable: false),
                    SubjectAreaName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectArea", x => x.SubjectAreaId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Payments",
                columns: table => new
                {
                    PaperPaymentId = table.Column<string>(maxLength: 150, nullable: false),
                    TellerNumber = table.Column<string>(maxLength: 150, nullable: true),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    AuthorName = table.Column<string>(maxLength: 150, nullable: true),
                    PaymentDate = table.Column<DateTimeOffset>(nullable: false),
                    PaperAuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaperPaymentId);
                    table.ForeignKey(
                        name: "FK_Payments_AspNetUsers_PaperAuthorId",
                        column: x => x.PaperAuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JournalContents",
                columns: table => new
                {
                    JournalContentId = table.Column<string>(maxLength: 150, nullable: false),
                    ContentTitle = table.Column<string>(maxLength: 150, nullable: true),
                    AuthorId = table.Column<string>(nullable: true),
                    JournalPosition = table.Column<int>(nullable: false),
                    JournalId = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalContents", x => x.JournalContentId);
                    table.ForeignKey(
                        name: "FK_JournalContents_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JournalContents_Journals_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journals",
                        principalColumn: "JournalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Papers",
                columns: table => new
                {
                    PaperId = table.Column<string>(maxLength: 150, nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    SavedPath = table.Column<string>(maxLength: 300, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 150, nullable: true),
                    PaperOriginalName = table.Column<string>(maxLength: 250, nullable: true),
                    ActualPath = table.Column<string>(maxLength: 300, nullable: true),
                    SubjectAreaId = table.Column<string>(maxLength: 150, nullable: true),
                    PaperTopic = table.Column<string>(maxLength: 250, nullable: true),
                    JournalId = table.Column<string>(maxLength: 150, nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
                    ThumbnailPath = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.PaperId);
                    table.ForeignKey(
                        name: "FK_Papers_SubjectArea_SubjectAreaId",
                        column: x => x.SubjectAreaId,
                        principalTable: "SubjectArea",
                        principalColumn: "SubjectAreaId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_JournalContents_AuthorId",
                table: "JournalContents",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalContents_JournalId",
                table: "JournalContents",
                column: "JournalId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Journals_IssnNo",
                table: "Journals",
                column: "IssnNo");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_JournalId",
                table: "Journals",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_Journals_VolumeName",
                table: "Journals",
                column: "VolumeName");

            migrationBuilder.CreateIndex(
                name: "IX_Papers_SubjectAreaId",
                table: "Papers",
                column: "SubjectAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PaperAuthorId",
                table: "Payments",
                column: "PaperAuthorId");
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
                name: "ContactUsSubmissions");

            migrationBuilder.DropTable(
                name: "JournalContents");

            migrationBuilder.DropTable(
                name: "Papers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Journals");

            migrationBuilder.DropTable(
                name: "SubjectArea");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
