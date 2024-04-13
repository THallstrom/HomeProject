using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TestSlogan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slogan",
                table: "CourseDescriptions");

            migrationBuilder.CreateTable(
                name: "Slogans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SloganName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseDescriptionId = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Slogans_CourseDescriptionId",
                table: "Slogans",
                column: "CourseDescriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slogans");

            migrationBuilder.AddColumn<string>(
                name: "Slogan",
                table: "CourseDescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
