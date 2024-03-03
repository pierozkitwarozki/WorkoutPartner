using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPartner.API.Migrations
{
    /// <inheritdoc />
    public partial class Addbodyparts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BodyParts",
                table: "Exercise",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BodyParts",
                table: "Exercise");
        }
    }
}
