using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class commonfileabolishedcert_path_successaddedtoCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_CommonFiles_CommonFileId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_CommonFiles_CommonFileId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCertificates_CommonFiles_CommonfileId",
                table: "UserCertificates");

            migrationBuilder.DropIndex(
                name: "IX_UserCertificates_CommonfileId",
                table: "UserCertificates");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_CommonFileId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CommonFileId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CommonfileId",
                table: "UserCertificates");

            migrationBuilder.DropColumn(
                name: "CommonFileId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CommonFileId",
                table: "Instructors");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "UserCertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewPath",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreviewPath",
                table: "Instructors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Certificate2Path",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SuccessRate",
                table: "Courses",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "UserCertificates");

            migrationBuilder.DropColumn(
                name: "PreviewPath",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "PreviewPath",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "Certificate2Path",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "SuccessRate",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CommonfileId",
                table: "UserCertificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommonFileId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommonFileId",
                table: "Instructors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCertificates_CommonfileId",
                table: "UserCertificates",
                column: "CommonfileId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserCertificates_CommonFiles_CommonfileId",
                table: "UserCertificates",
                column: "CommonfileId",
                principalTable: "CommonFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
