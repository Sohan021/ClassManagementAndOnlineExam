using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineexam.Migrations
{
    public partial class akjdsdss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Courses",
                newName: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Courses",
                newName: "UserId");
        }
    }
}
