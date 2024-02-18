using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPartner.API.Migrations
{
    /// <inheritdoc />
    public partial class AddSchemaName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ExerciseSchema",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ExerciseSchema");
        }
    }
}
