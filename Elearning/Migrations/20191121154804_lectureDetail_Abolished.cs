using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class lectureDetail_Abolished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CommonFiles_CertificateId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CommonFiles_PreviewId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Presentations_PresentationId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Questions_QuestionId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Videos_VideoId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_PresentationId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_QuestionId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_VideoId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_PreviewId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "PresentationId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Lectures");

            migrationBuilder.RenameColumn(
                name: "PreviewId",
                table: "Courses",
                newName: "PreviewPath");

            migrationBuilder.RenameColumn(
                name: "CertificateId",
                table: "Courses",
                newName: "CertificatePath");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Lectures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompletionDay",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "CompletionDay",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "PreviewPath",
                table: "Courses",
                newName: "PreviewId");

            migrationBuilder.RenameColumn(
                name: "CertificatePath",
                table: "Courses",
                newName: "CertificateId");

            migrationBuilder.AddColumn<int>(
                name: "PresentationId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_PresentationId",
                table: "Lectures",
                column: "PresentationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_QuestionId",
                table: "Lectures",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_VideoId",
                table: "Lectures",
                column: "VideoId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_PreviewId",
                table: "Courses",
                column: "PreviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CommonFiles_CertificateId",
                table: "Courses",
                column: "CertificateId",
                principalTable: "CommonFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CommonFiles_PreviewId",
                table: "Courses",
                column: "PreviewId",
                principalTable: "CommonFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Presentations_PresentationId",
                table: "Lectures",
                column: "PresentationId",
                principalTable: "Presentations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Questions_QuestionId",
                table: "Lectures",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Videos_VideoId",
                table: "Lectures",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
