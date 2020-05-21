using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class LectureDetailEradicated2_commonfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Aim",
                table: "Lectures",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonFileId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Lectures",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Lectures",
                maxLength: 1500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonFileId",
                table: "Instructors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_CommonFileId",
                table: "Lectures",
                column: "CommonFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CommonFileId",
                table: "Instructors",
                column: "CommonFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_CommonFiles_CommonFileId",
                table: "Instructors",
                column: "CommonFileId",
                principalTable: "CommonFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_CommonFiles_CommonFileId",
                table: "Lectures",
                column: "CommonFileId",
                principalTable: "CommonFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_CommonFiles_CommonFileId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CommonFiles_CommonFileId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CommonFileId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CommonFileId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Aim",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CommonFileId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CommonFileId",
                table: "Instructors");
        }
    }
}
