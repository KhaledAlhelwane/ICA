using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class newroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
       table: "AspNetRoles",
       columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
       values: new object[] { Guid.NewGuid().ToString(), "Driver", "Driver".ToUpper(), Guid.NewGuid().ToString() }
       ); migrationBuilder.InsertData(
       table: "AspNetRoles",
       columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
       values: new object[] { Guid.NewGuid().ToString(), "Unhcr", "Unhcr".ToUpper(), Guid.NewGuid().ToString() }
       );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM [dbo].[AspNetRoles]");
        }
    }
}
