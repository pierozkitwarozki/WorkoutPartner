using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPartner.API.Migrations
{
    /// <inheritdoc />
    public partial class Addequipmentowner : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_OwnerId",
                table: "Equipment",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_AspNetUsers_OwnerId",
                table: "Equipment",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_AspNetUsers_OwnerId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_OwnerId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Equipment");
        }
    }
}
