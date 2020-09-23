using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineexam.Migrations
{
    public partial class akjdsds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuestionNumber",
                table: "Tests",
                newName: "TotanQuestion");

            migrationBuilder.AddColumn<int>(
                name: "TotalMarks",
                table: "Tests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalMarks",
                table: "Tests");

            migrationBuilder.RenameColumn(
                name: "TotanQuestion",
                table: "Tests",
                newName: "QuestionNumber");
        }
    }
}
