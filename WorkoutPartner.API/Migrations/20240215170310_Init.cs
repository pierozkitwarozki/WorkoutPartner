using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPartner.API.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Exercise",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Exercise",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Exercise",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exercise_OwnerId",
                table: "Exercise",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_AspNetUsers_OwnerId",
                table: "Exercise",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_AspNetUsers_OwnerId",
                table: "Exercise");

            migrationBuilder.DropIndex(
                name: "IX_Exercise_OwnerId",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Exercise");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Exercise");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Exercise",
                newName: "Url");
        }
    }
}
