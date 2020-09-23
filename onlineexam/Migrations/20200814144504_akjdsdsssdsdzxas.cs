using Microsoft.EntityFrameworkCore.Migrations;

namespace onlineexam.Migrations
{
    public partial class akjdsdsssdsdzxas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_AspNetUsers_StudentsId",
                table: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_StudentsId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Tests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "Tests",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentsId",
                table: "Tests",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tests_StudentsId",
                table: "Tests",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_AspNetUsers_StudentsId",
                table: "Tests",
                column: "StudentsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
