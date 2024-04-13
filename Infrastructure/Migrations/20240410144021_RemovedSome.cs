using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseDescriptions_CourseDescriptionId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Slogans");

            migrationBuilder.DropTable(
                name: "CourseDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseDescriptionId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDescriptionId",
                table: "Courses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slogans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDescriptionId = table.Column<int>(type: "int", nullable: true),
                    SloganName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slogans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slogans_CourseDescriptions_CourseDescriptionId",
                        column: x => x.CourseDescriptionId,
                        principalTable: "CourseDescriptions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseDescriptionId",
                table: "Courses",
                column: "CourseDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Slogans_CourseDescriptionId",
                table: "Slogans",
                column: "CourseDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseDescriptions_CourseDescriptionId",
                table: "Courses",
                column: "CourseDescriptionId",
                principalTable: "CourseDescriptions",
                principalColumn: "Id");
        }
    }
}
