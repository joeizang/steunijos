using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Steunijos.Web.Migrations
{
    public partial class SimplifiedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Journals_JournalIssnNo",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Papers_Journals_JournalId",
                table: "Papers");

            migrationBuilder.DropIndex(
                name: "IX_Papers_JournalId",
                table: "Papers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_JournalIssnNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JournalIssnNo",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ActualPath",
                table: "Journals",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "Journals",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "SavedPath",
                table: "Journals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualPath",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Journals");

            migrationBuilder.DropColumn(
                name: "SavedPath",
                table: "Journals");

            migrationBuilder.AddColumn<string>(
                name: "JournalIssnNo",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Papers_JournalId",
                table: "Papers",
                column: "JournalId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_JournalIssnNo",
                table: "AspNetUsers",
                column: "JournalIssnNo");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Journals_JournalIssnNo",
                table: "AspNetUsers",
                column: "JournalIssnNo",
                principalTable: "Journals",
                principalColumn: "IssnNo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Papers_Journals_JournalId",
                table: "Papers",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "IssnNo",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
