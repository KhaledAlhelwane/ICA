using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class BueCloseRateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RatingTime",
                table: "Rating",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Check",
                table: "Bus",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingTime",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "Check",
                table: "Bus");
        }
    }
}
