using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CourseDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseDescriptionId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slogan = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDescriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseDescriptionId",
                table: "Courses",
                column: "CourseDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseDescriptions_CourseDescriptionId",
                table: "Courses",
                column: "CourseDescriptionId",
                principalTable: "CourseDescriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseDescriptions_CourseDescriptionId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseDescriptionId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDescriptionId",
                table: "Courses");
        }
    }
}
