using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class lectureChangedAlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Lectures",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PresentationId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Lectures",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Lectures",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Presentations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Speaker = table.Column<string>(maxLength: 50, nullable: true),
                    SlideCount = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    CrtUsr = table.Column<int>(nullable: false),
                    CrtDate = table.Column<DateTime>(nullable: false),
                    CrtHost = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presentations", x => x.Id);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Presentations_PresentationId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Questions_QuestionId",
                table: "Lectures");

            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Videos_VideoId",
                table: "Lectures");

            migrationBuilder.DropTable(
                name: "Presentations");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_PresentationId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_QuestionId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_VideoId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "PresentationId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Lectures");

            migrationBuilder.AlterColumn<int>(
                name: "InstructorId",
                table: "Lectures",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Instructors_InstructorId",
                table: "Lectures",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
