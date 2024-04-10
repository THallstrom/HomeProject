using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class teachers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_TeacherEntity_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherEntity",
                table: "TeacherEntity");

            migrationBuilder.RenameTable(
                name: "TeacherEntity",
                newName: "Teachers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Teachers_TeacherId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "TeacherEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherEntity",
                table: "TeacherEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_TeacherEntity_TeacherId",
                table: "Courses",
                column: "TeacherId",
                principalTable: "TeacherEntity",
                principalColumn: "Id");
        }
    }
}
