using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineexam.Migrations
{
    public partial class akjdsdsssdsd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotanQuestion",
                table: "Tests",
                newName: "TotalQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalQuestion",
                table: "Tests",
                newName: "TotanQuestion");
        }
    }
}
