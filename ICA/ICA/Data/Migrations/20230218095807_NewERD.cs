using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class NewERD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_Article_ArticleId",
                table: "Album");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_AspNetUsers_ApplicationUsersId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Album_AlbumId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_ITRequist_AspNetUsers_ApplicationUsersId",
                table: "ITRequist");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfArticle_Article_ArticleId",
                table: "TypeOfArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfArticle",
                table: "TypeOfArticle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ITRequist",
                table: "ITRequist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Article",
                table: "Article");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "TypeOfArticle",
                newName: "TypeOfArticles");

            migrationBuilder.RenameTable(
                name: "ITRequist",
                newName: "ITRequists");

            migrationBuilder.RenameTable(
                name: "Article",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Albums");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfArticle_ArticleId",
                table: "TypeOfArticles",
                newName: "IX_TypeOfArticles_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_ITRequist_ApplicationUsersId",
                table: "ITRequists",
                newName: "IX_ITRequists_ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Article_ApplicationUsersId",
                table: "News",
                newName: "IX_Articles_ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Album_ArticleId",
                table: "Albums",
                newName: "IX_Albums_ArticleId");

            migrationBuilder.AddColumn<int>(
                name: "AssosiationId",
                table: "News",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainAssociationId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainInterfaceId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "projectsId",
                table: "Albums",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfArticles",
                table: "TypeOfArticles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ITRequists",
                table: "ITRequists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Articles",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Albums",
                table: "Albums",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Assosiation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FaceBookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assosiation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainAssociation",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainAssociation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "MainInterface",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    served_over = table.Column<int>(type: "int", nullable: true),
                    facebook_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Emial_link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainInterface", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    project_title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo_picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Center = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssosiationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_projects_Assosiation_AssosiationId",
                        column: x => x.AssosiationId,
                        principalTable: "Assosiation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComplintDep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    persone_status = table.Column<bool>(type: "bit", nullable: false),
                    complient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplintDep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComplintDep_projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Postion = table.Column<bool>(type: "bit", nullable: false),
                    AssosiationId = table.Column<int>(type: "int", nullable: true),
                    projectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Member_Assosiation_AssosiationId",
                        column: x => x.AssosiationId,
                        principalTable: "Assosiation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Member_projects_projectsId",
                        column: x => x.projectsId,
                        principalTable: "projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Center",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    location_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    map = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contac_us = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    center_manger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectsId = table.Column<int>(type: "int", nullable: true),
                    ComplintDepId = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Center", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Center_ComplintDep_ComplintDepId",
                        column: x => x.ComplintDepId,
                        principalTable: "ComplintDep",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Center_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Center_projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "projects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AssosiationId",
                table: "News",
                column: "AssosiationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Center_ComplintDepId",
                table: "Center",
                column: "ComplintDepId");

            migrationBuilder.CreateIndex(
                name: "IX_Center_MemberId",
                table: "Center",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Center_ProjectsId",
                table: "Center",
                column: "ProjectsId");

            migrationBuilder.CreateIndex(
                name: "IX_ComplintDep_projectsId",
                table: "ComplintDep",
                column: "projectsId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_AssosiationId",
                table: "Member",
                column: "AssosiationId");

            migrationBuilder.CreateIndex(
                name: "IX_Member_projectsId",
                table: "Member",
                column: "projectsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_projects_AssosiationId",
                table: "projects",
                column: "AssosiationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums",
                column: "ArticleId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_MainAssociation_MainAssociationId",
                table: "Albums",
                column: "MainAssociationId",
                principalTable: "MainAssociation",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUsersId",
                table: "News",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Assosiation_AssosiationId",
                table: "News",
                column: "AssosiationId",
                principalTable: "Assosiation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITRequists_AspNetUsers_ApplicationUsersId",
                table: "ITRequists",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfArticles_Articles_ArticleId",
                table: "TypeOfArticles",
                column: "ArticleId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Articles_ArticleId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainAssociation_MainAssociationId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_MainInterface_MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_projects_projectsId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_AspNetUsers_ApplicationUsersId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Assosiation_AssosiationId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_Albums_AlbumId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_ITRequists_AspNetUsers_ApplicationUsersId",
                table: "ITRequists");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfArticles_Articles_ArticleId",
                table: "TypeOfArticles");

            migrationBuilder.DropTable(
                name: "Center");

            migrationBuilder.DropTable(
                name: "MainAssociation");

            migrationBuilder.DropTable(
                name: "MainInterface");

            migrationBuilder.DropTable(
                name: "ComplintDep");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "Assosiation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeOfArticles",
                table: "TypeOfArticles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ITRequists",
                table: "ITRequists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Articles",
                table: "News");

            migrationBuilder.DropIndex(
                name: "IX_Articles_AssosiationId",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Albums",
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

            migrationBuilder.DropColumn(
                name: "AssosiationId",
                table: "News");

            migrationBuilder.DropColumn(
                name: "MainAssociationId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "MainInterfaceId",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "projectsId",
                table: "Albums");

            migrationBuilder.RenameTable(
                name: "TypeOfArticles",
                newName: "TypeOfArticle");

            migrationBuilder.RenameTable(
                name: "ITRequists",
                newName: "ITRequist");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "Article");

            migrationBuilder.RenameTable(
                name: "Albums",
                newName: "Album");

            migrationBuilder.RenameIndex(
                name: "IX_TypeOfArticles_ArticleId",
                table: "TypeOfArticle",
                newName: "IX_TypeOfArticle_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_ITRequists_ApplicationUsersId",
                table: "ITRequist",
                newName: "IX_ITRequist_ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_ApplicationUsersId",
                table: "Article",
                newName: "IX_Article_ApplicationUsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArticleId",
                table: "Album",
                newName: "IX_Album_ArticleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeOfArticle",
                table: "TypeOfArticle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ITRequist",
                table: "ITRequist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Article",
                table: "Article",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_Article_ArticleId",
                table: "Album",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_AspNetUsers_ApplicationUsersId",
                table: "Article",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Album_AlbumId",
                table: "Images",
                column: "AlbumId",
                principalTable: "Album",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ITRequist_AspNetUsers_ApplicationUsersId",
                table: "ITRequist",
                column: "ApplicationUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfArticle_Article_ArticleId",
                table: "TypeOfArticle",
                column: "ArticleId",
                principalTable: "Article",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
