using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketDDD.Server.DB.Migrations
{
    public partial class Sessionize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionizeId",
                table: "EventDetail",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionizeId",
                table: "EventDetail");
        }
    }
}
