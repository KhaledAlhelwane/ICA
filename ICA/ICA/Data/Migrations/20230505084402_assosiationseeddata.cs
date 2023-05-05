using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class assosiationseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assosiation",
                columns: new[] { "Id", "About", "Email", "FaceBookLink", "FullName", "Manger", "PhoneNumber", "Photo" },
                values: new object[,]
                {
                    { 1, null, null, null, "عون", null, null, null },
                    { 2, null, null, null, "الميتم", null, null, null },
                    { 3, null, null, null, "صالة زنوبية", null, null, null },
                    { 4, null, null, null, "المدارس الخيريةالنموذجية", null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Assosiation",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
