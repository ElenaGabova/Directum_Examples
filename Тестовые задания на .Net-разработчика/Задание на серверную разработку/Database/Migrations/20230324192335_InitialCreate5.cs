using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Messages",
                newName: "UserContactId");

            migrationBuilder.RenameColumn(
                name: "ContactId",
                table: "Contacts",
                newName: "contactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserContactId",
                table: "Messages",
                newName: "ContactId");

            migrationBuilder.RenameColumn(
                name: "contactId",
                table: "Contacts",
                newName: "ContactId");
        }
    }
}
