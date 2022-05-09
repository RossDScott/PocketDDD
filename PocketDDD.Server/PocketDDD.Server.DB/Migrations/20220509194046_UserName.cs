using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketDDD.Server.DB.Migrations
{
    public partial class UserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "Users",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "GivenName");

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
