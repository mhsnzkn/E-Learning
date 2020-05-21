using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class usercoursedetail_lecturegroup_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LectureGroupId",
                table: "UserCourseDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCourseDetails_LectureGroupId",
                table: "UserCourseDetails",
                column: "LectureGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourseDetails_LectureGroups_LectureGroupId",
                table: "UserCourseDetails",
                column: "LectureGroupId",
                principalTable: "LectureGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCourseDetails_LectureGroups_LectureGroupId",
                table: "UserCourseDetails");

            migrationBuilder.DropIndex(
                name: "IX_UserCourseDetails_LectureGroupId",
                table: "UserCourseDetails");

            migrationBuilder.DropColumn(
                name: "LectureGroupId",
                table: "UserCourseDetails");
        }
    }
}
