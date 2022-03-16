using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registrar.Migrations
{
    public partial class DateCourseNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Students",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CourseNumber",
                table: "Courses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseNumber",
                table: "Courses");
        }
    }
}
