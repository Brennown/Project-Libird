using Microsoft.EntityFrameworkCore.Migrations;

namespace Libird.Data.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Borrowed",
                table: "Books",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Read",
                table: "Books",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Books",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrowed",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Read",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Books");
        }
    }
}
