using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class dbcorrectionv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainInterface_MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_projects_projectsId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArticleId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_projectsId",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "projectsId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainInterfaceId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainAssociationId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Albums",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArticleId",
                table: "Albums",
                column: "ArticleId",
                unique: true,
                filter: "[ArticleId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                unique: true,
                filter: "[MainAssociationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MainInterfaceId",
                table: "Albums",
                column: "MainInterfaceId",
                unique: true,
                filter: "[MainInterfaceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_projectsId",
                table: "Albums",
                column: "projectsId",
                unique: true,
                filter: "[projectsId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                principalTable: "MainAssociations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainInterface_MainInterfaceId",
                table: "Albums",
                column: "MainInterfaceId",
                principalTable: "MainInterface",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_projects_projectsId",
                table: "Albums",
                column: "projectsId",
                principalTable: "projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainInterface_MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_projects_projectsId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ArticleId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_projectsId",
                table: "Albums");

            migrationBuilder.AlterColumn<int>(
                name: "projectsId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainInterfaceId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainAssociationId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ArticleId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArticleId",
                table: "Albums",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_MainInterfaceId",
                table: "Albums",
                column: "MainInterfaceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_projectsId",
                table: "Albums",
                column: "projectsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainAssociations_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                principalTable: "MainAssociations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainInterface_MainInterfaceId",
                table: "Albums",
                column: "MainInterfaceId",
                principalTable: "MainInterface",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_projects_projectsId",
                table: "Albums",
                column: "projectsId",
                principalTable: "projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
