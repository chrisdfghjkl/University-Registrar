using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrar.Migrations
{
    public partial class DepartmentFixtwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "CourseDepartmentStudent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartmentStudent_DepartmentId",
                table: "CourseDepartmentStudent",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartmentStudent_Department_DepartmentId",
                table: "CourseDepartmentStudent",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartmentStudent_Department_DepartmentId",
                table: "CourseDepartmentStudent");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_CourseDepartmentStudent_DepartmentId",
                table: "CourseDepartmentStudent");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "CourseDepartmentStudent");
        }
    }
}
