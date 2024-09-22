using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudyBuddyAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inital2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answers",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "QuestionOptions",
                table: "Questions",
                newName: "Answer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Questions",
                newName: "QuestionOptions");

            migrationBuilder.AddColumn<string>(
                name: "Answers",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "Questions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
