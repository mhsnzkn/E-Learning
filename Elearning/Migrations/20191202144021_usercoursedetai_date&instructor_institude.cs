using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class usercoursedetai_dateinstructor_institude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBegin",
                table: "UserCourseDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "UserCourseDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Institution",
                table: "Instructors",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBegin",
                table: "UserCourseDetails");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "UserCourseDetails");

            migrationBuilder.DropColumn(
                name: "Institution",
                table: "Instructors");
        }
    }
}
