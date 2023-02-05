using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class SeedingRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(

           table: "AspNetRoles",
           columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
           values: new object[] { Guid.NewGuid().ToString(), "IT", "IT".ToUpper(), Guid.NewGuid().ToString() }
           );
            migrationBuilder.InsertData(

          table: "AspNetRoles",
          columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
          values: new object[] { Guid.NewGuid().ToString(), "Media", "Media".ToUpper(), Guid.NewGuid().ToString() }
          ); 
            migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
          values: new object[] { Guid.NewGuid().ToString(), "Orphanage", "Orphanage".ToUpper(), Guid.NewGuid().ToString() }
          );
            migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
          values: new object[] { Guid.NewGuid().ToString(), "PriamrySch", "PriamrySch".ToUpper(), Guid.NewGuid().ToString() }
          );
            migrationBuilder.InsertData(
         table: "AspNetRoles",
         columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
         values: new object[] { Guid.NewGuid().ToString(), "ElemantryFemale", "ElemantryFemale".ToUpper(), Guid.NewGuid().ToString() }
         );
            migrationBuilder.InsertData(
        table: "AspNetRoles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        values: new object[] { Guid.NewGuid().ToString(), "ElemantryMale", "ElemantryMale".ToUpper(), Guid.NewGuid().ToString() }
        );
            migrationBuilder.InsertData(
       table: "AspNetRoles",
       columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
       values: new object[] { Guid.NewGuid().ToString(), "ItRequist", "ItRequist".ToUpper(), Guid.NewGuid().ToString() }
       );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete FROM [dbo].[AspNetRoles]");
        }
    }
}
