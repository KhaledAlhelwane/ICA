using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class UserWithRoels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO [dbo].[AspNetUserRoles](UserId,RoleId) SELECT '0604fe3c-ed4b-4fad-a0a3-e71c9c650443',Id FROM [dbo].[AspNetRoles] ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [dbo].[AspNetUserRoles] WHERE UserId='0604fe3c-ed4b-4fad-a0a3-e71c9c650443'");

        }
    }
}
