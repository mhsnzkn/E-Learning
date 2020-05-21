using Microsoft.EntityFrameworkCore.Migrations;

namespace Elearning.Migrations
{
    public partial class userexamresultoptimizedforresults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "UserExamResults",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalCorrect",
                table: "UserExamResults",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalQuestion",
                table: "UserExamResults",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Success",
                table: "UserExamResults");

            migrationBuilder.DropColumn(
                name: "TotalCorrect",
                table: "UserExamResults");

            migrationBuilder.DropColumn(
                name: "TotalQuestion",
                table: "UserExamResults");
        }
    }
}
