using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class lectureDetailEradicated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Lectures");

            migrationBuilder.AddColumn<int>(
                name: "UserCourseDetailId",
                table: "UserQuestionChoices",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserQuestionChoices_UserCourseDetailId",
                table: "UserQuestionChoices",
                column: "UserCourseDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserQuestionChoices_UserCourseDetails_UserCourseDetailId",
                table: "UserQuestionChoices",
                column: "UserCourseDetailId",
                principalTable: "UserCourseDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserQuestionChoices_UserCourseDetails_UserCourseDetailId",
                table: "UserQuestionChoices");

            migrationBuilder.DropIndex(
                name: "IX_UserQuestionChoices_UserCourseDetailId",
                table: "UserQuestionChoices");

            migrationBuilder.DropColumn(
                name: "UserCourseDetailId",
                table: "UserQuestionChoices");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Lectures",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Lectures",
                nullable: false,
                defaultValue: 0);
        }
    }
}
