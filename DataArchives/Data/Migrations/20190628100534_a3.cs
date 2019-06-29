using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataArchives.Data.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistration",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<int>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    Head = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    SectionParrentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sections_Sections_SectionParrentId",
                        column: x => x.SectionParrentId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<int>(nullable: false),
                    Public = table.Column<bool>(nullable: false),
                    Head = table.Column<string>(nullable: false),
                    Body = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    SectionParrentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Sections_SectionParrentId",
                        column: x => x.SectionParrentId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImagesDataArchives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Data = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    ArticleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesDataArchives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagesDataArchives_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImagesDataArchives_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SectionParrentId",
                table: "Articles",
                column: "SectionParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesDataArchives_ArticleId",
                table: "ImagesDataArchives",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ImagesDataArchives_UserId",
                table: "ImagesDataArchives",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_SectionParrentId",
                table: "Sections",
                column: "SectionParrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_UserId",
                table: "Sections",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagesDataArchives");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DateRegistration",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
