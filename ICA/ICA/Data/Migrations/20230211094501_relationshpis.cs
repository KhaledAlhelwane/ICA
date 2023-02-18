using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICA.Data.Migrations
{
    public partial class relationshpis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatePuplished = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ITRequist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequistTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfRequist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaintenanceNote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequistStatus = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ITRequist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ITRequist_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumTitel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleArabic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TypeOfArticle_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Album",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArticleId",
                table: "Album",
                column: "ArticleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_ApplicationUsersId",
                table: "Article",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_AlbumId",
                table: "Images",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_ITRequist_ApplicationUsersId",
                table: "ITRequist",
                column: "ApplicationUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfArticle_ArticleId",
                table: "TypeOfArticle",
                column: "ArticleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ITRequist");

            migrationBuilder.DropTable(
                name: "TypeOfArticle");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Article");
        }
    }
}
