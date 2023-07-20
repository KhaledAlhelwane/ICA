﻿// <auto-generated />
using System;
using ICA.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ICA.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230720082126_addedrealtimToBus")]
    partial class addedrealtimToBus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ICA.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AlbumTitel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int?>("MainAssociationId")
                        .HasColumnType("int");

                    b.Property<int?>("MainInterfaceId")
                        .HasColumnType("int");

                    b.Property<int?>("projectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId")
                        .IsUnique()
                        .HasFilter("[ArticleId] IS NOT NULL");

                    b.HasIndex("MainAssociationId")
                        .IsUnique()
                        .HasFilter("[MainAssociationId] IS NOT NULL");

                    b.HasIndex("MainInterfaceId")
                        .IsUnique()
                        .HasFilter("[MainInterfaceId] IS NOT NULL");

                    b.HasIndex("projectsId")
                        .IsUnique()
                        .HasFilter("[projectsId] IS NOT NULL");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("ICA.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecoundName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("ICA.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AssosiationId")
                        .HasColumnType("int");

                    b.Property<string>("ContentArabic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatePuplished")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("TitleArabic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEnglish")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfArticles")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUsersId");

                    b.HasIndex("AssosiationId");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ICA.Models.Assosiation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assosiation");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "عون"
                        },
                        new
                        {
                            Id = 2,
                            FullName = "الميتم"
                        },
                        new
                        {
                            Id = 3,
                            FullName = "صالة زنوبية"
                        },
                        new
                        {
                            Id = 4,
                            FullName = "المدارس الخيرية النموذجية"
                        });
                });

            modelBuilder.Entity("ICA.Models.Bus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("Check")
                        .HasColumnType("bit");

                    b.Property<string>("Des")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DigitDes")
                        .HasColumnType("float");

                    b.Property<double>("DigitSurce")
                        .HasColumnType("float");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RealTIME")
                        .HasColumnType("datetime2");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TIME")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bus");
                });

            modelBuilder.Entity("ICA.Models.Center", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ComplintDepId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectsId")
                        .HasColumnType("int");

                    b.Property<string>("center_manger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contac_us")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("map")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ComplintDepId");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.HasIndex("ProjectsId");

                    b.ToTable("Centers");
                });

            modelBuilder.Entity("ICA.Models.ComplintDep", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("complient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("persone_status")
                        .HasColumnType("bit");

                    b.Property<int?>("projectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("projectsId");

                    b.ToTable("ComplintDep");
                });

            modelBuilder.Entity("ICA.Models.Images", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AlbumId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ICA.Models.ITRequist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApplicationUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MaintenanceNote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequistStatus")
                        .HasColumnType("bit");

                    b.Property<string>("RequistTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicalNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfRequist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUsersId");

                    b.ToTable("ITRequists");
                });

            modelBuilder.Entity("ICA.Models.MainAssociation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MainAssociations");
                });

            modelBuilder.Entity("ICA.Models.MainInterface", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Emial_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facebook_link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("served_over")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MainInterface");
                });

            modelBuilder.Entity("ICA.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AssosiationId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Postion")
                        .HasColumnType("bit");

                    b.Property<string>("PostionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("projectsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssosiationId");

                    b.HasIndex("projectsId")
                        .IsUnique();

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ICA.Models.projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AssosiationId")
                        .HasColumnType("int");

                    b.Property<string>("Center")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo_picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("project_title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssosiationId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("ICA.Models.Rating", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RatingLevel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RatingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Rating", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ICA.Models.Album", b =>
                {
                    b.HasOne("ICA.Models.Article", "Article")
                        .WithOne("Album")
                        .HasForeignKey("ICA.Models.Album", "ArticleId");

                    b.HasOne("ICA.Models.MainAssociation", "MainAssociation")
                        .WithOne("Album")
                        .HasForeignKey("ICA.Models.Album", "MainAssociationId");

                    b.HasOne("ICA.Models.MainInterface", "MainInterface")
                        .WithOne("Album")
                        .HasForeignKey("ICA.Models.Album", "MainInterfaceId");

                    b.HasOne("ICA.Models.projects", "projects")
                        .WithOne("Album")
                        .HasForeignKey("ICA.Models.Album", "projectsId");

                    b.Navigation("Article");

                    b.Navigation("MainAssociation");

                    b.Navigation("MainInterface");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("ICA.Models.Article", b =>
                {
                    b.HasOne("ICA.Models.ApplicationUser", "ApplicationUsers")
                        .WithMany("Articles")
                        .HasForeignKey("ApplicationUsersId");

                    b.HasOne("ICA.Models.Assosiation", "Assosiation")
                        .WithMany("Articles")
                        .HasForeignKey("AssosiationId");

                    b.Navigation("ApplicationUsers");

                    b.Navigation("Assosiation");
                });

            modelBuilder.Entity("ICA.Models.Center", b =>
                {
                    b.HasOne("ICA.Models.ComplintDep", "ComplintDep")
                        .WithMany()
                        .HasForeignKey("ComplintDepId");

                    b.HasOne("ICA.Models.Member", "Member")
                        .WithOne("center")
                        .HasForeignKey("ICA.Models.Center", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICA.Models.projects", "Projects")
                        .WithMany("centers")
                        .HasForeignKey("ProjectsId");

                    b.Navigation("ComplintDep");

                    b.Navigation("Member");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ICA.Models.ComplintDep", b =>
                {
                    b.HasOne("ICA.Models.projects", "projects")
                        .WithMany("ComplintDeps")
                        .HasForeignKey("projectsId");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("ICA.Models.Images", b =>
                {
                    b.HasOne("ICA.Models.Album", "Album")
                        .WithMany("Images")
                        .HasForeignKey("AlbumId");

                    b.Navigation("Album");
                });

            modelBuilder.Entity("ICA.Models.ITRequist", b =>
                {
                    b.HasOne("ICA.Models.ApplicationUser", "ApplicationUsers")
                        .WithMany("ITRequists")
                        .HasForeignKey("ApplicationUsersId");

                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("ICA.Models.Member", b =>
                {
                    b.HasOne("ICA.Models.Assosiation", "Assosiation")
                        .WithMany("Members")
                        .HasForeignKey("AssosiationId");

                    b.HasOne("ICA.Models.projects", "projects")
                        .WithOne("Member")
                        .HasForeignKey("ICA.Models.Member", "projectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assosiation");

                    b.Navigation("projects");
                });

            modelBuilder.Entity("ICA.Models.projects", b =>
                {
                    b.HasOne("ICA.Models.Assosiation", "Assosiation")
                        .WithMany("Projects")
                        .HasForeignKey("AssosiationId");

                    b.Navigation("Assosiation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ICA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ICA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ICA.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ICA.Models.Album", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("ICA.Models.ApplicationUser", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("ITRequists");
                });

            modelBuilder.Entity("ICA.Models.Article", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("ICA.Models.Assosiation", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("Members");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("ICA.Models.MainAssociation", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("ICA.Models.MainInterface", b =>
                {
                    b.Navigation("Album");
                });

            modelBuilder.Entity("ICA.Models.Member", b =>
                {
                    b.Navigation("center");
                });

            modelBuilder.Entity("ICA.Models.projects", b =>
                {
                    b.Navigation("Album");

                    b.Navigation("ComplintDeps");

                    b.Navigation("Member");

                    b.Navigation("centers");
                });
#pragma warning restore 612, 618
        }
    }
}
