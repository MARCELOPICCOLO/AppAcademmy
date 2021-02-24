using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppAcademmy.Migrations
{
    public partial class RelationsAppAcademmy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    createAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owners",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owners", x => new { x.ClientId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_owners_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "signatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_signatures_clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: true),
                    timeCourse = table.Column<int>(type: "int", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OwnerClientId = table.Column<int>(type: "int", nullable: true),
                    OwnerCourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_owners_OwnerClientId_OwnerCourseId",
                        columns: x => new { x.OwnerClientId, x.OwnerCourseId },
                        principalTable: "owners",
                        principalColumns: new[] { "ClientId", "CourseId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSignature",
                columns: table => new
                {
                    SignaturesId = table.Column<int>(type: "int", nullable: false),
                    coursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSignature", x => new { x.SignaturesId, x.coursesId });
                    table.ForeignKey(
                        name: "FK_CourseSignature_courses_coursesId",
                        column: x => x.coursesId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSignature_signatures_SignaturesId",
                        column: x => x.SignaturesId,
                        principalTable: "signatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_OwnerClientId_OwnerCourseId",
                table: "courses",
                columns: new[] { "OwnerClientId", "OwnerCourseId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSignature_coursesId",
                table: "CourseSignature",
                column: "coursesId");

            migrationBuilder.CreateIndex(
                name: "IX_owners_ClientId",
                table: "owners",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_signatures_ClientId",
                table: "signatures",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSignature");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "signatures");

            migrationBuilder.DropTable(
                name: "owners");

            migrationBuilder.DropTable(
                name: "clients");
        }
    }
}
