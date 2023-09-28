using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class visitcounter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<int>(
                name: "visitCounter",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropColumn(
                name: "visitCounter",
                table: "Articles");

         
        }
    }
}
