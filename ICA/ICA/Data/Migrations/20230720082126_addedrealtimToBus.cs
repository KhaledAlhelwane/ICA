using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class addedrealtimToBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RealTIME",
                table: "Bus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RealTIME",
                table: "Bus");
        }
    }
}
