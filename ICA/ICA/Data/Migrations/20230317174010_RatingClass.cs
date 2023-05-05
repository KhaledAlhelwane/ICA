using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class RatingClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainAssociation_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_ComplintDep_ComplintDepId",
                table: "Center");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_Member_MemberId",
                table: "Center");

            migrationBuilder.DropForeignKey(
                name: "FK_Center_projects_ProjectsId",
                table: "Center");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_Assosiation_AssosiationId",
                table: "Member");

            migrationBuilder.DropForeignKey(
                name: "FK_Member_projects_projectsId",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Member",
                table: "Member");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainAssociation",
                table: "MainAssociation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Center",
                table: "Center");

            migrationBuilder.RenameTable(
                name: "Member",
                newName: "Members");

            migrationBuilder.RenameTable(
                name: "MainAssociation",
                newName: "MainAssociations");

            migrationBuilder.RenameTable(
                name: "Center",
                newName: "Centers");

            migrationBuilder.RenameIndex(
                name: "IX_Member_projectsId",
                table: "Members",
                newName: "IX_Members_projectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Member_AssosiationId",
                table: "Members",
                newName: "IX_Members_AssosiationId");

            migrationBuilder.RenameIndex(
                name: "IX_Center_ProjectsId",
                table: "Centers",
                newName: "IX_Centers_ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Center_MemberId",
                table: "Centers",
                newName: "IX_Centers_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Center_ComplintDepId",
                table: "Centers",
                newName: "IX_Centers_ComplintDepId");

            migrationBuilder.AlterColumn<string>(
                name: "Manger",
                table: "MainAssociations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Members",
                table: "Members",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainAssociations",
                table: "MainAssociations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Centers",
                table: "Centers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RatingLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                principalTable: "MainAssociations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_ComplintDep_ComplintDepId",
                table: "Centers",
                column: "ComplintDepId",
                principalTable: "ComplintDep",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_Members_MemberId",
                table: "Centers",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Centers_projects_ProjectsId",
                table: "Centers",
                column: "ProjectsId",
                principalTable: "projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Assosiation_AssosiationId",
                table: "Members",
                column: "AssosiationId",
                principalTable: "Assosiation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_projects_projectsId",
                table: "Members",
                column: "projectsId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_ComplintDep_ComplintDepId",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_Members_MemberId",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Centers_projects_ProjectsId",
                table: "Centers");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_Assosiation_AssosiationId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Members_projects_projectsId",
                table: "Members");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Members",
                table: "Members");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MainAssociations",
                table: "MainAssociations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Centers",
                table: "Centers");

            migrationBuilder.RenameTable(
                name: "Members",
                newName: "Member");

            migrationBuilder.RenameTable(
                name: "MainAssociations",
                newName: "MainAssociation");

            migrationBuilder.RenameTable(
                name: "Centers",
                newName: "Center");

            migrationBuilder.RenameIndex(
                name: "IX_Members_projectsId",
                table: "Member",
                newName: "IX_Member_projectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_AssosiationId",
                table: "Member",
                newName: "IX_Member_AssosiationId");

            migrationBuilder.RenameIndex(
                name: "IX_Centers_ProjectsId",
                table: "Center",
                newName: "IX_Center_ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_Centers_MemberId",
                table: "Center",
                newName: "IX_Center_MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Centers_ComplintDepId",
                table: "Center",
                newName: "IX_Center_ComplintDepId");

            migrationBuilder.AlterColumn<string>(
                name: "Manger",
                table: "MainAssociation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Member",
                table: "Member",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MainAssociation",
                table: "MainAssociation",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Center",
                table: "Center",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainAssociation_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                principalTable: "MainAssociation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Center_ComplintDep_ComplintDepId",
                table: "Center",
                column: "ComplintDepId",
                principalTable: "ComplintDep",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Center_Member_MemberId",
                table: "Center",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Center_projects_ProjectsId",
                table: "Center",
                column: "ProjectsId",
                principalTable: "projects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_Assosiation_AssosiationId",
                table: "Member",
                column: "AssosiationId",
                principalTable: "Assosiation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Member_projects_projectsId",
                table: "Member",
                column: "projectsId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
