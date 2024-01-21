using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PocketDDD.Server.DB.Migrations
{
    public partial class SessionizeItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionizeId",
                table: "Tracks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionizeId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionizeId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "SessionizeId",
                table: "Sessions");
        }
    }
}
