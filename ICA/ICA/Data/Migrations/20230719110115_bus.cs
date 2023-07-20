using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class bus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitSurce = table.Column<double>(type: "float", nullable: false),
                    Photo2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitDes = table.Column<double>(type: "float", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Des = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TIME = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "المدارس الخيرية النموذجية");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bus");

            migrationBuilder.UpdateData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 4,
                column: "FullName",
                value: "المدارس الخيريةالنموذجية");
        }
    }
}
