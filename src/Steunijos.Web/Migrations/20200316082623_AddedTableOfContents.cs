using Microsoft.EntityFrameworkCore.Migrations;

namespace Steunijos.Web.Migrations
{
    public partial class AddedTableOfContents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropIndex(
                name: "IX_JournalContents_JournalIssnNo",
                table: "JournalContents");*/

            migrationBuilder.AddColumn<string>(
                name: "JournalContentId",
                table: "Journals",
                nullable: true);

            /*migrationBuilder.CreateIndex(
                name: "IX_JournalContents_JournalIssnNo",
                table: "JournalContents",
                column: "JournalIssnNo",
                unique: true);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropIndex(
                name: "IX_JournalContents_JournalIssnNo",
                table: "JournalContents");*/

            migrationBuilder.DropColumn(
                name: "JournalContentId",
                table: "Journals");

            /*migrationBuilder.CreateIndex(
                name: "IX_JournalContents_JournalIssnNo",
                table: "JournalContents",
                column: "JournalIssnNo");*/
        }
    }
}
