using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Steunijos.Web.Migrations
{
    public partial class AddContactUsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUsSubmissions");
        }
    }
}
