using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class AssosiationUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutEnglish",
                table: "Assosiation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssosiationURL",
                table: "Assosiation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullNameEnglish",
                table: "Assosiation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutEnglish",
                table: "Assosiation");

            migrationBuilder.DropColumn(
                name: "AssosiationURL",
                table: "Assosiation");

            migrationBuilder.DropColumn(
                name: "FullNameEnglish",
                table: "Assosiation");
        }
    }
}
